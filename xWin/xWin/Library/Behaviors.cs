using System;
using System.Windows.Forms;
using System.Collections.Generic;
using xWin;
using Google.Protobuf;
using static Configuration.Types;
using static Configuration.Types.Action;

namespace xWin.Library
{
    public partial class Interpreter : IInterpreter
    {

        public interface AnAction
        {
            void feed(KeyboardMouseState kmstate);
        }

        public struct ASpecialAction : AnAction
        {
            private readonly SpecialAction sa;
            public void feed(KeyboardMouseState kmstate)
            {
                if (sa != SpecialAction.Pass) { kmstate.special.Enqueue(sa); }
            }
            public ASpecialAction(SpecialAction sa)
            {
                this.sa = sa;
            }
        }

        public struct ANormalAction : AnAction
        {
            private readonly Keys a;
            public void feed(KeyboardMouseState kmstate)
            {
                if (a != Keys.None) { kmstate.pressed.Enqueue(a); }
            }
            public ANormalAction(Keys a)
            {
                this.a = a;
            }
        }

        public struct ABehavior
        {
            public AnAction press, hold, release, stay;
            public ABehavior(Behavior b)
            {
                if (b.OnPress.OneActionCase == OneActionOneofCase.Keybind)
                {
                    press = new ANormalAction((Keys)b.OnPress.Keybind);
                }
                else
                {
                    press = new ASpecialAction(b.OnPress.SpecialAction);
                }

                if (b.OnHold.OneActionCase == OneActionOneofCase.Keybind)
                {
                    hold = new ANormalAction((Keys)b.OnHold.Keybind);
                }
                else
                {
                    hold = new ASpecialAction(b.OnHold.SpecialAction);
                }

                if (b.OnRelease.OneActionCase == OneActionOneofCase.Keybind)
                {
                    release = new ANormalAction((Keys)b.OnRelease.Keybind);
                }
                else
                {
                    release = new ASpecialAction(b.OnRelease.SpecialAction);
                }

                if (b.OnStay.OneActionCase == OneActionOneofCase.Keybind)
                {
                    stay = new ANormalAction((Keys)b.OnStay.Keybind);
                }
                else
                {
                    stay = new ASpecialAction(b.OnStay.SpecialAction);
                }
            }
        }

        public interface ControllerAction
        {
            void Reset();
        }

        public class ButtonBehavior : ControllerAction
        {
            private readonly ABehavior behavior;

            private readonly bool toggle_press, toggle_release;

            private bool press_state, release_state;

            //was it down last time?
            private bool previous_state;

            public void Reset() { press_state = false; release_state = false; previous_state = false; }

            public ButtonBehavior(Behavior b)
            {
                behavior = new ABehavior(b);
                toggle_press = b.OnPressToggle;
                toggle_release = b.OnReleaseToggle;
                press_state = false;
                release_state = false;
                previous_state = false;
            }

            public void Act(bool state, KeyboardMouseState kmstate)
            {
                if (previous_state)
                {
                    if (state) /*hold*/ { behavior.hold.feed(kmstate); }
                    else//release
                    {
                        if (!toggle_release)
                        {
                            behavior.release.feed(kmstate);
                        }
                        else
                        {
                            release_state = !release_state;
                        }
                    }
                }
                else
                {
                    if (state)//press
                    {
                        if (!toggle_press)
                        {
                            behavior.press.feed(kmstate);
                        }
                        else
                        {
                            press_state = !press_state;
                        }
                    }
                    else /*stay*/ { behavior.stay.feed(kmstate); }
                }
                if (toggle_press && press_state) { behavior.press.feed(kmstate); }
                if (toggle_release && release_state) { behavior.release.feed(kmstate); }
                
                previous_state = state;
            }
        }

        public interface StickAction : ControllerAction
        {
            void Act(short x, short y, KeyboardMouseState kmstate);
        }
        public class RegionStickBehavior : StickAction
        {
            private byte? last_region;
            private readonly List<ABehavior> region_behaviors;
            private readonly ABehavior centered;
            private readonly List<short> region_sizes;
            private readonly ushort deadzone;
            private readonly short start;
            public RegionStickBehavior(Stick s)
            {
                if (s.StayBehavior.OnPressToggle || s.StayBehavior.OnReleaseToggle)
                    throw new Exception("Toggle is not supported on Sticks");
                deadzone = (ushort)s.Deadzone;
                start = (short)s.RegionStart;
                short totalsize = 0;
                centered = new ABehavior(s.StayBehavior);
                region_behaviors = new List<ABehavior>();
                region_sizes = new List<short>();
                for (var i = 0; i < s.Regions.Count; i++)
                {
                    if (s.Regions[i].Behavior.OnPressToggle || s.Regions[i].Behavior.OnReleaseToggle)
                        throw new Exception("Toggle is not supported on Sticks");
                    region_behaviors.Add(new ABehavior(s.Regions[i].Behavior));
                    region_sizes.Add((short)s.Regions[i].Range);
                    totalsize += region_sizes[i];
                }
                if (totalsize != 360)
                    throw new Exception("Regions not fully defined, size must equal exactly 360");
            }
            public void Reset()
            {
                last_region = null;
            }
            public void Act(short x, short y, KeyboardMouseState kmstate)
            {
                var ps = new PolarStick(x, y, deadzone);
                byte? region;
                if (ps.theta == null)
                    region = null;
                else
                {
                    //set region offsets
                    ps.theta -= (short)(region_sizes[0] / 2);
                    ps.theta -= start;

                    short? t = ps.theta;
                    region = 0;
                    while (t > 0)
                    {
                        region += 1;
                        t = (short)(t - region_sizes[0]);
                    }
                    region -= 1;
                }

                if (region != last_region)
                {
                    if (region == null) { centered.press.feed(kmstate); }
                    else { region_behaviors[(int)region].press.feed(kmstate); }
                    if (last_region == null) { centered.release.feed(kmstate); }
                    else { region_behaviors[(int)last_region].release.feed(kmstate); }
                }
                else
                {
                    if (region == null) { centered.hold.feed(kmstate); }
                    else { region_behaviors[(int)region].hold.feed(kmstate); }
                }//stay all others
                 //foreach (var r in region_behaviors) { r.stay.feed(kmstate); }
                if (region != null && last_region != null) { centered.stay.feed(kmstate); }
                //else
                {
                    for (byte? i = 0; i < region_behaviors.Count; i++)
                    {
                        if (i != region && i != last_region) { region_behaviors[(int)i].stay.feed(kmstate); }
                    }
                }
            }
        }

        public class MouseStickBehavior : StickAction
        {
            private readonly ushort deadzone;
            private readonly bool invert_lr, invert_ud;
            public MouseStickBehavior(Stick s)
            {
                deadzone = (ushort)s.Deadzone;
                invert_lr = s.InvertLr;
                invert_ud = s.InvertUd;
            }
            public void Reset() { }
            public void Act(short x, short y, KeyboardMouseState kmstate)
            {
                kmstate.mouse_movement.Enqueue(new PolarStick((short)(invert_lr ? -x : x), (short)(invert_lr ? -y : y), deadzone));
            }
        }

        public class TriggerBehavior : ControllerAction
        {
            //private readonly byte deadzone;
            //private ABehavior unpressed;
            private readonly List<ABehavior> behaviors;
            private readonly List<byte> regions;
            private int last_region;
            public TriggerBehavior(Trigger t)
            {
                ushort size = (ushort)t.Deadzone;
                if (t.Deadzone == 0) { throw new Exception("Deadzone must be greater than 0"); }
                regions = new List<byte>();
                regions.Add((byte)t.Deadzone);
                behaviors = new List<ABehavior>();
                behaviors.Add(new ABehavior(t.Unpressed));
                foreach (var r in t.Regions)
                {
                    size += (ushort)r.Range;
                    regions.Add((byte)size);
                    behaviors.Add(new ABehavior(r.Behavior));
                }
                if (size > 255) { throw new Exception("trigger regions and deadzone must sum to exactly 255"); }
            }
            public void Act(byte value, KeyboardMouseState kmstate)
            {
                var r = 0;
                while (r < regions.Count && regions[r] > value) { r++; }
                r--;
                if (last_region == r) { behaviors[r].hold.feed(kmstate); }
                else
                {
                    behaviors[r].press.feed(kmstate);
                    behaviors[last_region].release.feed(kmstate);
                }
                for (var i = 0; i < regions.Count; i++)
                    if (i != r && i != last_region)
                        behaviors[i].stay.feed(kmstate);
            }
            public void Reset() { last_region = 0; }
        }
    }
}