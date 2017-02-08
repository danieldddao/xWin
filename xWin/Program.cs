using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            while(!Console.KeyAvailable)
            {
                Thread.Sleep(200);
                if (c.isConnected())
                {
                    if (!msg) {
                        Console.WriteLine("Controller Connected!");
                        msg = true;
                    }
                    if (c.isButtonAPressed())
                    {
                        Console.WriteLine("Button A pressed!");
                    }
                    if (c.isButtonBPressed())
                    {
                        Console.WriteLine("Button B pressed!");
                    }
                    if (c.isButtonXPressed())
                    {
                        Console.WriteLine("Button X pressed!");
                    }
                    if (c.isButtonYPressed())
                    {
                        Console.WriteLine("Button Y pressed!");
                    }
                    if (c.isButtonBackPressed())
                    {
                        Console.WriteLine("Button Back pressed!");
                    }
                    if (c.isButtonDPadDownPressed())
                    {
                        Console.WriteLine("Button DPadDown pressed!");
                    }
                    if (c.isButtonDPadUpPressed())
                    {
                        Console.WriteLine("Button DPadUp pressed!");
                    }
                    if (c.isButtonDPadLeftPressed())
                    {
                        Console.WriteLine("Button DPadLeft pressed!");
                    }
                    if (c.isButtonDPadRightPressed())
                    {
                        Console.WriteLine("Button DPadRight pressed!");
                    }
                    if (c.isButtonLeftShoulderPressed())
                    {
                        Console.WriteLine("Button LeftShoulder pressed!");
                    }
                    if (c.isButtonRightShoulderPressed())
                    {
                        Console.WriteLine("Button RightShoulder pressed!");
                    }
                    if (c.isButtonLeftThumbPressed())
                    {
                        Console.WriteLine("Button LeftThumb pressed!");
                    }
                    if (c.isButtonRightThumbPressed())
                    {
                        Console.WriteLine("Button RightThumb pressed!");
                    }
                    if (c.isButtonStartPressed())
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
