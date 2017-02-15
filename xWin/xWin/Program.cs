using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using SharpDX.XInput;
using xWin.Library;

namespace xWin
{
	class Program
	{
        static void Main(string[] args)
		{
            XController c = new XController(new Controller(UserIndex.One));
            bool msg = false;
            while (true)
            {
                Thread.Sleep(200);
                if (c.IsConnected())
                {
                    if (!msg) {
                        Console.WriteLine("Controller Connected!");
                        msg = true;
                    }
                    if (c.IsButtonAPressed())
                    {
                        Console.WriteLine("Button A pressed!");
                         XKeyBoard.PressKey(Keys.A);
                    }
                    if (c.IsButtonBPressed())
                    {
                        Console.WriteLine("Button B pressed!");
                    }
                    if (c.IsButtonXPressed())
                    {
                        Console.WriteLine("Button X pressed!");
                    }
                    if (c.IsButtonYPressed())
                    {
                        Console.WriteLine("Button Y pressed!");
                    }
                    if (c.IsButtonBackPressed())
                    {
                        Console.WriteLine("Button Back pressed!");
                    }
                    if (c.IsButtonDPadDownPressed())
                    {
                        Console.WriteLine("Button DPadDown pressed!");
                    }
                    if (c.IsButtonDPadUpPressed())
                    {
                        Console.WriteLine("Button DPadUp pressed!");
                    }
                    if (c.IsButtonDPadLeftPressed())
                    {
                        Console.WriteLine("Button DPadLeft pressed!");
                    }
                    if (c.IsButtonDPadRightPressed())
                    {
                        Console.WriteLine("Button DPadRight pressed!");
                    }
                    if (c.IsButtonLeftShoulderPressed())
                    {
                        Console.WriteLine("Button LeftShoulder pressed!");
                    }
                    if (c.IsButtonRightShoulderPressed())
                    {
                        Console.WriteLine("Button RightShoulder pressed!");
                    }
                    if (c.IsButtonLeftThumbPressed())
                    {
                        Console.WriteLine("Button LeftThumb pressed!");
                    }
                    if (c.IsButtonRightThumbPressed())
                    {
                        Console.WriteLine("Button RightThumb pressed!");
                    }
                    if (c.IsButtonStartPressed())
                    {
                        Console.WriteLine("Button Start pressed!");
                    }
                } else
                {
                    Console.WriteLine("Controller Disconnected!");
                    msg = false;
                }     
            }
		}
	}
}
