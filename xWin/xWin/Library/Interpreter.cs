using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWin;
using SharpDX.XInput;
using Google.Protobuf;

using static BasicControl.Types;

namespace xWin.Library
{
    public interface IInterpreter
    {

    }
    public partial class Interpreter : IInterpreter
    {
        public struct KeyboardMouseState
        {
            public Queue<Keys> pressed;
            public Queue<SpecialAction> special;

            public struct coord { public int x; public int y; }; 
            public coord mouse_movement;
        }

        protected Dictionary<GamepadButtonFlags, ButtonBehavior> button_map { get; private set; }
        protected readonly StickBehavior LeftStick, RightStick;
        protected readonly TriggerBehavior LeftTrigger, RightTrigger;
        protected readonly List<ControllerAction> all_connections;


        private readonly Dictionary<GamepadFlags, ButtonBehavior> input_mapping;

        public Interpreter(BasicControl c)
        {
            /*
            * map ButtonAction inheritors to ControllerButtons: 
            * button_map[ControllerButton.A] = new `ButtonAction(this)`;
            */

            all_connections = new List<ControllerAction>();
            input_mapping = new Dictionary<GamepadFlags, ButtonBehavior>();
            foreach (GamepadFlags s in c.ButtonMap.Keys)
            {
                input_mapping[s] = new ButtonBehavior(c.ButtonMap[(int)s]);
            }
            LeftStick = GetStickBehavior(c.LeftStick);
            RightStick = GetStickBehavior(c.RightStick);
            LeftTrigger = new TriggerBehavior(c.LeftTrigger);
            RightTrigger = new TriggerBehavior(c.RightTrigger);
        }

        /*Clear the old States*/
        public void Reset()
        {
            foreach (var b in button_map.Values) { b.Reset(); }
        }

        public KeyboardMouseState NextState(Gamepad g)
        {
            var kms = new KeyboardMouseState();
            /*
                Get Stick and Trigger Regions, and put them into the GamepadFlags constructor
            */

            byte lt = LeftTrigger.GetRegion(g.LeftTrigger);
            byte rt = RightTrigger.GetRegion(g.RightTrigger);
            byte? ls = LeftStick.Act(g.LeftThumbX, g.LeftThumbY, kms);
            byte? rs = LeftStick.Act(g.RightThumbX, g.RightThumbY, kms);
            bool lss = false, rss = false;
            if (ls == null) { lss = true; ls = 0; }
            if (rs == null) { rss = true; rs = 0; }
            var state = new GamepadFlags(g.Buttons,lt == 0, rt == 0, lss, rss, false, false, lt, rt, (byte)ls, (byte)rs);
            foreach(GamepadFlags flags in input_mapping.Keys)
            {
                input_mapping[flags].Act(flags & state, state, kms);
            }
            return kms;
        }
    }
}
