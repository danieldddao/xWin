using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using System.Collections;
using SharpDX.DirectInput;
using SharpDX.XInput;

namespace MSTest.Library
{
    [TestClass]
    public class DI2XITest
    {
        [TestInitialize]
        public void Setup() { }

        [TestCleanup]
        public void Cleanup() { }

        [TestMethod]
        public void TestDI2XIConvertFlags()
        {
            foreach( DI2XI.Buttons f in Enum.GetValues(typeof(DI2XI.Buttons)))
            {
                if (f != DI2XI.Buttons.LeftTrigger && f != DI2XI.Buttons.RightTrigger)
                {
                    Assert.AreEqual(DI2XI.ConvertFlags(f).ToString(), f.ToString(),f.ToString());
                }
                else
                {
                    Assert.AreEqual(DI2XI.ConvertFlags(f), SharpDX.XInput.GamepadButtonFlags.None, f.ToString());
                }
            }
        }
        
        //dependent on ConvertFlagsTest being successful sadly
        //all combinations of 12 button 
        [TestMethod]
        public void TestDI2XIExhaustiveAllButtonCombinations_REQUIRES_TestDI2XIConvertFlags()
        {
            for(ushort bitarray = 0; (bitarray & (11111<<12)) == 0; bitarray++ )
            {
                var js = new JoystickState();
                for (var i = 0; i < 12; ++i)
                {
                    js.Buttons[i] = (bitarray & (1 << i)) != 0;
                }
                for(var d = -1; d < 8; d ++)
                {
                    js.PointOfViewControllers[0] = d*4500;
                    var state = DI2XI.di2xi(js);
                    for (var i = 0; i < 6; ++i)
                    {
                        if (js.Buttons[i])
                        {
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(DI2XI.ConvertFlags((DI2XI.Buttons)i)), "1");
                        }
                        else
                        {
                            Assert.IsFalse(state.Gamepad.Buttons.HasFlag(DI2XI.ConvertFlags((DI2XI.Buttons)i)), "2");
                        }
                    }
                    if(js.Buttons[6])
                    {
                        Assert.AreEqual(state.Gamepad.LeftTrigger, (byte)255, "5");
                    }
                    else
                    {
                        Assert.AreEqual(state.Gamepad.LeftTrigger, (byte)0, "3");
                    }
                    if(js.Buttons[7])
                    {
                        Assert.AreEqual(state.Gamepad.RightTrigger, (byte)255, "6");
                    }
                    else
                    {
                        Assert.AreEqual(state.Gamepad.RightTrigger, (byte)0, "4");
                    }

                    for (var i = 8; i < 12; ++i)
                    {
                        if (js.Buttons[i])
                        {
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(DI2XI.ConvertFlags((DI2XI.Buttons)i)), "7");
                        }
                        else
                        {
                            Assert.IsFalse(state.Gamepad.Buttons.HasFlag(DI2XI.ConvertFlags((DI2XI.Buttons)i)), "8");
                        }
                    }
                    int total = 0;
                    total += (byte)(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp) ? 1 : 0);
                    total += (byte)(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight) ? 1 : 0);
                    total += (byte)(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown) ? 1 : 0);
                    total += (byte)(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft) ? 1 : 0);
                    Assert.IsTrue(total < 3, "only 2 dpad buttons can be pressed at a time");
                    switch(d)
                    {
                        case 0:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
                            break;
                        case 1:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
                            break;
                        case 2:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
                            break;
                        case 3:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
                            break;
                        case 4:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
                            break;
                        case 5:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
                            break;
                        case 6:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
                            break;
                        case 7:
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
                            Assert.IsTrue(state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
                            break;
                        default:
                            Assert.AreEqual(total, 0);
                            break;
                    }
                    
                }
            }
        }

        [TestMethod]
        public void TestDI2XILeftStickConvert()
        {
            for(short x = -32000; x <= 32000; x+=1000)
            {
                for(short y = -32000; y <= 32000; y += 1000)
                {
                    var js = new JoystickState();
                    js.X = x;
                    js.Y = y;
                    var state = DI2XI.di2xi(js);
                    Assert.AreEqual(x, state.Gamepad.LeftThumbX);
                    Assert.AreEqual(y, state.Gamepad.LeftThumbY);
                    Assert.AreEqual((short)0, state.Gamepad.RightThumbX);
                    Assert.AreEqual((short)0, state.Gamepad.RightThumbY);
                }
            }
        }

        [TestMethod]
        public void TestDI2XIRightStickConvert()
        {
            for (short x = -32000; x <= 32000; x += 1000)
            {
                for (short y = -32000; y <= 32000; y += 1000)
                {
                    var js = new JoystickState();
                    js.RotationX = x;
                    js.RotationY = y;
                    var state = DI2XI.di2xi(js);
                    Assert.AreEqual(x, state.Gamepad.RightThumbX);
                    Assert.AreEqual(y, state.Gamepad.RightThumbY);
                    Assert.AreEqual((short)0, state.Gamepad.LeftThumbX);
                    Assert.AreEqual((short)0, state.Gamepad.LeftThumbY);
                }
            }
        }

        [TestMethod]
        public void TestDI2XIStickSetup()
        {
            // TODO 
            // How TF does this class even work and what does it even do
        }
    }
}
