using System;
using System.Windows.Forms;
using System.Collections.Generic;
using xWin;
using Google.Protobuf;
using static BasicControl.Types;
using System.Diagnostics;

namespace xWin.Library
{
    public partial class Interpreter : IInterpreter
    {
        protected class ButtonBehavior
        {
            public class AnAction
            {
                private readonly List<Keys> ks, release_ks;
                private readonly List<SpecialAction> sas, release_sas;
                private bool justdone, delayed, firstpress;
                private Stopwatch sw, delay;
                private TimeSpan RepeatTime, DelayTime;
                public AnAction(Actions a, Actions b, TimeSpan t, TimeSpan t2)
                {
                    ks = new List<Keys>();
                    sas = new List<SpecialAction>();
                    release_ks = new List<Keys>();
                    release_sas = new List<SpecialAction>();
                    delay = new Stopwatch();
                    sw = new Stopwatch();
                    RepeatTime = t;
                    DelayTime = t2;
                    if (a == null)
                        a = new Actions { Keybinds = { }, SpecialActions = { } };
                    if (b == null)
                        b = new Actions { Keybinds = { }, SpecialActions = { } };
                    if (a != null)
                    {
                        if (a.Keybinds != null)
                            foreach (var aa in a.Keybinds)
                            {
                                Keys aaa = (Keys)aa;
                                if (aaa == Keys.Shift)
                                    aaa = Keys.ShiftKey;
                                else if (aaa == Keys.Control)
                                    aaa = Keys.ControlKey;
                                else if (aaa == Keys.Alt)
                                    aaa = Keys.Menu;
                                else if (aaa == Keys.KeyCode)
                                    continue;
                                //else if (b.Keybinds.Contains(aa))
                                //    continue;
                                    
                                ks.Add(aaa);
                            }
                        if (a.SpecialActions != null)
                            foreach (var aa in a.SpecialActions)
                            {
                                sas.Add(aa);
                                //if (! b.SpecialActions.Contains(aa)) { sas.Add(aa); }
                            }
                    }
                    if (b != null)
                    {
                        if (b.Keybinds != null)
                        {
                            foreach (var bb in b.Keybinds)
                            {
                                Keys bbb = (Keys)bb;
                                if (bbb == Keys.Shift)
                                    bbb = Keys.ShiftKey;
                                else if (bbb == Keys.Control)
                                    bbb = Keys.ControlKey;
                                else if (bbb == Keys.Alt)
                                    bbb = Keys.Menu;
                                else if (bbb == Keys.KeyCode)
                                    continue;
                                //else if (a.Keybinds.Contains(bb))
                                //    continue;
                                if (!ks.Contains(bbb)) { release_ks.Add(bbb); }
                                
                            }
                        }
                        if (b.SpecialActions != null)
                        {
                            foreach (var bb in b.SpecialActions)
                            {

                                if (!sas.Contains(bb)){ release_sas.Add(bb); }
                                //if (! a.SpecialActions.Contains(bb)) { release_sas.Add(bb); }
                            }
                        }
                    }
                    justdone = false;
                    delayed = false;
                    firstpress = false;
                    delay.Reset();
                    sw.Reset();
                }
                public void feed(KeyboardMouseState kmstate)
                {
                    if (!firstpress)
                    {
                        foreach (var k in ks) { kmstate.pressed.Enqueue(k); }
                        firstpress = true;
                        delay.Start();
                    }
                    else if(!delayed)
                    {
                        if(delay.Elapsed >= DelayTime)
                        {
                            delayed = true;
                            foreach (var k in ks) { kmstate.pressed.Enqueue(k); }
                            sw.Start();
                        }
                    }
                    else if (sw.Elapsed >= RepeatTime)
                    {
                        foreach (var k in ks) { kmstate.pressed.Enqueue(k); }
                        sw.Restart();
                    }

                    if (!justdone)
                    {
                        foreach (var k in release_ks) { kmstate.released.Enqueue(k); }
                        foreach (var sa in sas) { kmstate.special.Enqueue(sa); }
                        foreach (var sa in release_sas) { kmstate.r_special.Enqueue(sa); }
                    }
                    justdone = true;
                }
                public void Pass()
                {
                    justdone = false;
                    delayed = false;
                    firstpress = false;
                    delay.Reset();
                    sw.Reset();
                }
            }
            private AnAction press, hold, release, stay;
            private readonly bool toggle_press, toggle_release;

            private bool press_state, release_state;

            private bool previous_state;

            private readonly List<GamepadFlags> blacklist;
            public void Reset() { press_state = false; release_state = false; previous_state = false; }

            public ButtonBehavior(Behavior b, TimeSpan t, TimeSpan t2)
            {
                press = new AnAction(b.OnPress, b.OnStay, t, t2);
                hold = new AnAction(b.OnHold, b.OnPress, t, t2);
                release = new AnAction(b.OnRelease, b.OnHold, t, t2);
                stay = new AnAction(b.OnStay, b.OnRelease, t, t2);
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

                if (IsBlacklisted(g))
                {
                    if (toggle_press && press_state) { press.feed(kmstate); }
                    if (toggle_release && release_state) { release.feed(kmstate); }
                    return;
                }


                if (previous_state)
                {
                    if (state) /*hold*/
                    {
                        press.Pass();
                        hold.feed(kmstate);
                        release.Pass();
                        stay.Pass();
                    }
                    else//release
                    {
                        if (!toggle_release)
                        {
                            press.Pass();
                            hold.Pass();
                            release.feed(kmstate);
                            stay.Pass();
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
                            press.feed(kmstate);
                            hold.Pass();
                            release.Pass();
                            stay.Pass();
                        }
                        else { press_state = !press_state; }
                    }
                    else /*stay*/
                    {
                        press.Pass();
                        hold.Pass();
                        release.Pass();
                        stay.feed(kmstate);
                    }
                }
                if (toggle_press && press_state) { press.feed(kmstate); }
                if (toggle_release && release_state) { release.feed(kmstate); }

                previous_state = state;
            }
        }

        private interface StickBehavior
        {
            byte Act(short x, short y, ref KeyboardMouseState kms);
        }

        public class RegionStickBehavior : StickBehavior
        {
            private readonly List<short> region_sizes;
            private readonly ushort deadzone;
            private readonly short start;
            public RegionStickBehavior(Stick s)
            {
                if(s == null)
                {
                    s = new Stick
                    {
                        Deadzone = 1,
                        RegionStart = 0,
                        Regions = { }
                    };
                }
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
            public byte Act(short x, short y, ref KeyboardMouseState kms)
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
            return s.ControlMouse ? (StickBehavior)new MouseStickBehavior(s) : new RegionStickBehavior(s);
        }

        private class MouseStickBehavior : StickBehavior
        {
            private readonly ushort deadzone;
            private readonly bool invert_lr, invert_ud;
            public MouseStickBehavior(Stick s)
            {
                deadzone = (ushort)s.Deadzone;
                invert_lr = s.InvertLr;
                invert_ud = s.InvertUd;
            }
            public byte Act(short x, short y, ref KeyboardMouseState kmstate)
            {
                if (Math.Sqrt(x * x + y * y) < deadzone)
                {
                    kmstate.mouse_movement.x = 0;
                    kmstate.mouse_movement.y = 0;
                    return 0;
                }
                kmstate.mouse_movement.x = x;
                kmstate.mouse_movement.y = y;

                //Console.WriteLine(kmstate.mouse_movement.x.ToString()+","+ kmstate.mouse_movement.y.ToString());
                return 1;
            }
        }

        public class TriggerBehavior
        {
            private readonly List<Int16> regions;
            public TriggerBehavior(Trigger t)
            {
                if (t == null) { t = new Trigger(); t.Deadzone = 255; }
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
                //Console.WriteLine(value.ToString()+","+r.ToString());
                return r;
            }
        }
    }
}