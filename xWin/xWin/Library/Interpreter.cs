using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWin;
using SharpDX.XInput;
using Google.Protobuf;

using static Configuration.Types;

namespace xWin.Library
{
  public partial class Interpreter
  {
    public struct KeyboardMouseState
    {
      public Queue<Keys> pressed;
      public Queue<SpecialAction> special;
      public Queue<PolarStick> mouse_movement;
    }

    protected Dictionary<GamepadButtonFlags, ButtonBehavior> button_map { get; private set; }
    protected readonly StickAction LeftStick, RightStick;
    protected readonly TriggerBehavior LeftTrigger, RightTrigger;
    protected readonly List<ControllerAction> all_connections;
    protected State last_state { get; private set; }
    protected State current_state
    {
      get { return current_state; }
      set { last_state = current_state; current_state = value; }
    }

    public Interpreter(Configuration c)
    {
      /*
      * map ButtonAction inheritors to ControllerButtons: 
      * button_map[ControllerButton.A] = new `ButtonAction(this)`;
      */
      all_connections = new List<ControllerAction>();
      foreach (GamepadButtonFlags b in Enum.GetValues(typeof(GamepadButtonFlags)))
      {
        button_map[b] = new ButtonBehavior(c.ButtonMap[(Int32)b]);

        all_connections.Add(button_map[b]);
      }
      LeftStick  = c.LeftStick.ControlMouse  ? (StickAction) new MouseStickBehavior(c.LeftStick)  : new RegionStickBehavior(c.LeftStick);
      RightStick = c.RightStick.ControlMouse ? (StickAction) new MouseStickBehavior(c.RightStick) : new RegionStickBehavior(c.RightStick);
      all_connections.Add(LeftStick);
      all_connections.Add(RightStick);
      LeftTrigger  = new TriggerBehavior(c.LeftTrigger);
      RightTrigger = new TriggerBehavior(c.RightTrigger);
      all_connections.Add(LeftTrigger);
      all_connections.Add(RightTrigger);
    }

    /*Clear the old States*/
    public void Reset()
    {
      current_state = new State();
      current_state = new State();
      foreach (var b in button_map.Values) { b.Reset(); }
    }

    /*The Method that should be in the main loop*/
    public KeyboardMouseState NextState(State s)
    {
      current_state = s;
      var gamepad = current_state.Gamepad;
      //run Action for each Button (there's probably a cleaner way to write this)
      //button_map[GamepadButtonFlags.A].Action(current_state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A));
      //etc...
      var kmstate = new KeyboardMouseState();
      foreach(GamepadButtonFlags k in button_map.Keys)
      {
        button_map[k].Act(gamepad.Buttons.HasFlag(k),kmstate);
      }
      LeftStick.Act(gamepad.LeftThumbX, gamepad.LeftThumbY, kmstate);
      RightStick.Act(gamepad.RightThumbX, gamepad.RightThumbY, kmstate);
      LeftTrigger.Act(gamepad.LeftTrigger, kmstate);
      RightTrigger.Act(gamepad.RightTrigger, kmstate);
      return kmstate;
    }
  }
}
