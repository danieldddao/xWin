using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using xWin.Library;
using SharpDX.XInput;

namespace xWin
{
	class Program
	{
        static void Main(string[] args)
		{
            XControllerImplementation c = new XControllerImplementation();
            while (true)
            {
                
                if (c.IsConnected())
                {
                    c.UpdateSate();
                    /*foreach(var button in c.ButtonsPressed())
                    {
                        Console.WriteLine(button.Key + " is pressed: " + button.Value);
                    }
                    foreach(var thumb in c.GetLeftCart())
                    {
                        Console.WriteLine("Left stick " + thumb.Key + ": " + thumb.Value);
                    }
                    foreach(var thumb in c.GetRightCart())
                    {
                        Console.WriteLine("Right " + thumb.Key + ": " + thumb.Value);
                    }
                    Console.WriteLine("Left trigger: " + c.GetLeftTrigger());
                    Console.WriteLine("Right trigger:" + c.GetRightTrigger());*/
                    c.MoveCurser();
                    if (c.ButtonsPressed()["A"]) XControllerImplementation.LeftDown();
                    else XControllerImplementation.LeftUp();
                    if (c.ButtonsPressed()["B"]) XControllerImplementation.RightClick();
                    //Thread.Sleep(200);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Controller Disconnected!");
                }     
            }
		}
	}
}
