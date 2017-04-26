﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using static TypingControl.Types;
using SharpDX.XInput;

namespace xWin.Library
{
    public class TypingInterpreter
    {
        private Dictionary<GamepadFlags,KeyboardSet> keysets;
        private KeyboardSet defaultset;
        private String current;
        private GamepadFlags select_mask, t1_mask, t2_mask;
        private struct KApack
        {
            public KeyboardAction ka;
            public List<GamepadFlags> blacklist;
            public bool isBlacklisted(GamepadFlags state)
            {
                foreach(var flags in blacklist)
                {
                    if (state & flags) { return true; }
                }
                return false;
            }
        }

        private Dictionary<GamepadFlags, KApack> pressed,held,released,stayed;

        private Dictionary<GamepadFlags, int> t1, t2;


        private Interpreter.TriggerBehavior LT, RT;
        private Interpreter.RegionStickBehavior LS, RS;

        public struct TypingState
        {
            public string Text;
            public Queue<KeyboardAction> Actions;
            public int t1, t2;
        }

        private GamepadFlags previous_state;
        public TypingInterpreter(TypingControl tc)
        {
            current = "";
            LT = new Interpreter.TriggerBehavior(tc.LeftTrigger);
            RT = new Interpreter.TriggerBehavior(tc.RightTrigger);

            LS = new Interpreter.RegionStickBehavior(tc.LeftStick);
            RS = new Interpreter.RegionStickBehavior(tc.RightStick);

            t1 = new Dictionary<GamepadFlags, int>();
            t2 = new Dictionary<GamepadFlags, int>();
            var index = 0;
            t1_mask = new GamepadFlags(0);
            foreach (var a in tc.Tier1)
            {
                t1.Add(new GamepadFlags(a), index++);
                t1_mask |= new GamepadFlags(a);
            }
            index = 0;
            t2_mask = new GamepadFlags(0);
            foreach (var a in tc.Tier2)
            {
                t2.Add(new GamepadFlags(a), index++);
                t2_mask |= new GamepadFlags(a);
            }
            if (tc.Tier1.Count == tc.Base.Count && tc.Tier2.Count == tc.Base.Subcount)
                defaultset = tc.Base;
            else
                throw new IndexOutOfRangeException("Keyset does not match the shape of the selection array");
            keysets = new Dictionary<GamepadFlags, KeyboardSet>();
            var ks = tc.KeyboardSelect;
            select_mask = new GamepadFlags(0);
            foreach (var a in ks.Keys)
            {
                select_mask |= new GamepadFlags(a);
                if (tc.Tier1.Count == ks[a].Count && tc.Tier2.Count == ks[a].Subcount)
                    keysets.Add(new GamepadFlags(a), tc.KeyboardSelect[a]);
                else
                    throw new IndexOutOfRangeException("Keyset does not match the shape of the selection array");
            }
            pressed = new Dictionary<GamepadFlags, KApack>();
            held = new Dictionary<GamepadFlags, KApack>();
            released = new Dictionary<GamepadFlags, KApack>();
            stayed = new Dictionary<GamepadFlags, KApack>();
            var tcb = tc.Bindings;
            if(tcb == null)
            {
                tcb = new Google.Protobuf.Collections.MapField<int, KeyboardActionContainer>();
            }
            foreach(var a in tcb.Keys)
            {
                var ka = new KApack();
                ka.ka = tcb[a].Binding;
                ka.blacklist = new List<GamepadFlags>();
                switch (tc.Bindings[a].WhenActive)
                {
                    case ActiveWhen.Pressed:
                        pressed.Add(new GamepadFlags(a), ka);
                        break;
                    case ActiveWhen.Held:
                        held.Add(new GamepadFlags(a), ka);
                        break;
                    case ActiveWhen.Released:
                        released.Add(new GamepadFlags(a), ka);
                        break;
                    case ActiveWhen.Stayed:
                        stayed.Add(new GamepadFlags(a), ka);
                        break;
                }

            }

            previous_state = new GamepadFlags(0,true,true,true,true);
            Console.WriteLine("t1_mask:" + t1_mask.ToString());
            Console.WriteLine("t2_mask:" + t2_mask.ToString());

            Console.WriteLine("select_mask:" + select_mask.ToString());
        }

        public void Reset()
        {
            previous_state = new GamepadFlags(0);
        }

        public TypingState NextState(Gamepad g)
        {
            var ts = new TypingState();
            ts.Text = current;
            ts.Actions = new Queue<KeyboardAction>();
            byte lt = LT.GetRegion(g.LeftTrigger);
            byte rt = RT.GetRegion(g.RightTrigger);
            Interpreter.KeyboardMouseState k = new Interpreter.KeyboardMouseState();
            byte ls = LS.Act(g.LeftThumbX, g.LeftThumbY, ref k);
            byte rs = RS.Act(g.RightThumbX, g.RightThumbY, ref k);
            var state = new GamepadFlags(g.Buttons, lt, rt, ls, rs);
            //Console.WriteLine((state * act_mask).ToString());
            /*
                Check Keyboard Actions
                Then Determine the Keyset
                Get the current string and save it to "current"
                if new is not null, replace ts.Text
            */
            foreach (var flags in pressed.Keys)
            {
                if(! (previous_state & flags))
                {
                    if(state & flags)
                    {
                        if(pressed[flags].isBlacklisted(state)) { continue; }
                        ts.Actions.Enqueue(pressed[flags].ka);
                    }
                }
            }

            foreach (var flags in held.Keys)
            {
                if (previous_state & flags)
                {
                    if (state & flags)
                    {
                        if (held[flags].isBlacklisted(state)) { continue; }
                        ts.Actions.Enqueue(held[flags].ka);
                    }
                }
            }

            foreach (var flags in released.Keys)
            {
                if (previous_state & flags)
                {
                    if (!(state & flags))
                    {
                        if(released[flags].isBlacklisted(state)) { continue; }
                        ts.Actions.Enqueue(released[flags].ka);
                    }
                }
            }
            foreach (var flags in stayed.Keys)
            {
                if (!(previous_state & flags))
                {
                    if (!(state & flags))
                    {
                        if (stayed[flags].isBlacklisted(state)) { continue; }
                        ts.Actions.Enqueue(stayed[flags].ka);
                    }
                }

            }
            ts.t1 = t1.ContainsKey(state * t1_mask) ? t1[state * t1_mask] : -1;
            ts.t2 = t2.ContainsKey(state * t2_mask) ? t2[state * t2_mask] : -1;
            if (!(ts.t1 > -1 && ts.t2 > -1)) { current = ""; }
            else { current = keysets.ContainsKey(state * select_mask) ? keysets[state * select_mask].Set[ts.t1].Subset[ts.t2] : defaultset.Set[ts.t1].Subset[ts.t2]; }
            
            if (current.Length != 0) { ts.Text = current; }
            previous_state = state;
            return ts;
        }
    }
}
