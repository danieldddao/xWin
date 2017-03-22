using System;
using System.Windows.Forms;
using System.Collections.Generic;
using xWin;
using Google.Protobuf;
using static BasicControl.Types;

namespace xWin.Library
{
    public partial class Interpreter : IInterpreter
    { 
        protected class ButtonBehavior
        {
            public class AnAction
            {
                private readonly List<Keys> ks;
                private readonly List<SpecialAction> sas;
                public AnAction(Actions a)
                {
                    ks = new List<Keys>();
                    sas = new List<SpecialAction>();
                    if (a != null)
                    {
                        if (a.Keybinds != null)
                            foreach (var aa in a.Keybinds) { ks.Add((Keys)aa); }
                        if (a.SpecialActions != null)
                            foreach (var aa in a.SpecialActions) { sas.Add(aa); }
                    }
                }
                public void feed(KeyboardMouseState kmstate)
                {
                    foreach (var k in ks) { kmstate.pressed.Enqueue(k); }
                    foreach (var sa in sas) { kmstate.special.Enqueue(sa); }
                }
            }
            private AnAction press, hold, release, stay;
            private readonly bool toggle_press, toggle_release;

            private bool press_state, release_state;
            
            private bool previous_state;

            private readonly List<GamepadFlags> blacklist;
            public void Reset() { press_state = false; release_state = false; previous_state = false; }

            public ButtonBehavior(Behavior b)
            {

                press = new AnAction(b.OnPress);

                hold = new AnAction(b.OnHold);
                release = new AnAction(b.OnRelease);
                stay = new AnAction(b.OnStay);
                toggle_press = b.OnPressToggle;
                toggle_release = b.OnReleaseToggle;
                press_state = false;
                release_state = false;
                previous_state = false;
                blacklist = new List<GamepadFlags>();
                if (b.Blacklist != null) 
                    foreach (var bl in b.Blacklist) { blacklist.Add(new GamepadFlags(bl)); }
            }
            private bool IsBlacklisted(GamepadFlags g)
            {
                foreach (var f in blacklist)
                {
                    if (g & f) { return true; }
                }
                return false;
            }
            public void Act(bool state, GamepadFlags g, KeyboardMouseState kmstate)
            {
                
                if(IsBlacklisted(g))
                {
                    if (toggle_press && press_state) { press.feed(kmstate); }
                    if (toggle_release && release_state) { release.feed(kmstate); }
                    return;
                }
                
                
                if (previous_state)
                {
                    if (state) /*hold*/ { hold.feed(kmstate); }
                    else//release
                    {
                        if (!toggle_release) { release.feed(kmstate); }
                        else { release_state = !release_state; }
                    }
                }
                else
                {
                    if (state)//press
                    {
                        if (!toggle_press) { press.feed(kmstate); }
                        else { press_state = !press_state; }
                    }
                    else /*stay*/ { stay.feed(kmstate); }
                }
                if (toggle_press && press_state) { press.feed(kmstate); }
                if (toggle_release && release_state) { release.feed(kmstate); }
                
                previous_state = state;
            }
        }

        private interface StickBehavior
        {
            byte Act(short x, short y, KeyboardMouseState kms);
        }

        protected class RegionStickBehavior : StickBehavior
        {
            private readonly List<short> region_sizes;
            private readonly ushort deadzone;
            private readonly short start;
            public RegionStickBehavior(Stick s)
            {
                deadzone = (ushort)s.Deadzone;
                start = (short)s.RegionStart;
                uint totalsize = 0;
                region_sizes = new List<short>();
                foreach (var i in s.Regions)
                {
                    region_sizes.Add((short)i);
                    totalsize += i;
                }
                if (totalsize < 360) { region_sizes.Add((short)(360 - totalsize)); }
                else if (totalsize > 360) { throw new Exception("Regions not fully defined, size must be less than or equal to 360"); }
            }
            //region 0 is the deadzone
            public byte Act(short x, short y, KeyboardMouseState kms)
            {
                var ps = new PolarStick(x, y, deadzone);
                byte? region;
                if (ps.theta == null)
                    region = 0;
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
                }
                return (byte)region;
            }
        }

        private static StickBehavior GetStickBehavior(Stick s)
        {
            if (s == null) { return new RegionStickBehavior(new Stick()); }
            return s.ControlMouse ? (StickBehavior) new MouseStickBehavior(s) : new RegionStickBehavior(s);
        }

        protected class MouseStickBehavior : StickBehavior
        {
            private readonly ushort deadzone;
            private readonly bool invert_lr, invert_ud;
            public MouseStickBehavior(Stick s)
            {
                deadzone = (ushort)s.Deadzone;
                invert_lr = s.InvertLr;
                invert_ud = s.InvertUd;
            }
            public byte Act(short x, short y, KeyboardMouseState kmstate)
            {
                if(Math.Sqrt(x*x+y*y) < deadzone)
                {
                    kmstate.mouse_movement = new KeyboardMouseState.coord { x = 0, y = 0 };
                    return 0;
                }
                kmstate.mouse_movement = new KeyboardMouseState.coord {x = x, y = y};
                    return 1;
            }
        }

        protected class TriggerBehavior
        {
            private readonly List<Int16> regions;
            public TriggerBehavior(Trigger t)
            {
                if(t == null) { t = new Trigger(); t.Deadzone = 255; }
                var size = t.Deadzone;
                if (t.Deadzone == 0) { throw new Exception("Deadzone must be greater than 0"); }
                regions = new List<Int16>();
                regions.Add((byte)size);
                if (t.Regions != null)
                {
                    foreach (var r in t.Regions)
                    {
                        size += r;
                        regions.Add((byte)size);
                    }
                }
                if (size > 255) { throw new Exception("trigger regions and deadzone must sum to exactly 255"); }
            }
            public byte GetRegion(byte value)
            {
                byte r = 0;
                while (r < regions.Count && regions[r] < value) { r++; }
                
                return r;
            }
        }
    }
}