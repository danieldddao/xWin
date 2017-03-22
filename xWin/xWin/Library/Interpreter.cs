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
        
        private readonly StickBehavior LeftStick, RightStick;
        private readonly TriggerBehavior LeftTrigger, RightTrigger;
        private readonly List<ButtonBehavior> all_connections;
        
        private readonly Dictionary<GamepadFlags, ButtonBehavior> input_mapping;

        public Interpreter(BasicControl c)
        {
            /*
            * map ButtonAction inheritors to ControllerButtons: 
            * button_map[ControllerButton.A] = new `ButtonAction(this)`;
            */

            all_connections = new List<ButtonBehavior>();
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
            foreach (var b in input_mapping.Values) { b.Reset(); }
        }

        public KeyboardMouseState NextState(Gamepad g)
        {
            var kms = new KeyboardMouseState();
            kms.mouse_movement = new KeyboardMouseState.coord();
            kms.pressed = new Queue<Keys>();
            kms.special = new Queue<SpecialAction>();
            /*
                Get Stick and Trigger Regions, and put them into the GamepadFlags constructor
            */

            byte lt = LeftTrigger.GetRegion(g.LeftTrigger);
            byte rt = RightTrigger.GetRegion(g.RightTrigger);
            byte ls = LeftStick.Act(g.LeftThumbX, g.LeftThumbY, kms);
            byte rs = RightStick.Act(g.RightThumbX, g.RightThumbY, kms);
            var state = new GamepadFlags(g.Buttons, lt, rt, ls, rs);

            foreach (GamepadFlags flags in input_mapping.Keys)
            {
                input_mapping[flags].Act(state & flags, state, kms);
            }
            return kms;
        }
    }
}
