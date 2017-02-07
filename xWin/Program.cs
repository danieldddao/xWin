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
                Thread.Sleep(300);
                if (c.isConnected())
                {
                    if (!msg) {
                        Console.WriteLine("Controller Connected!");
                        msg = true;
                    }
                    if (c.buttonAPressed())
                    {
                        Console.WriteLine("Button A pressed!");
                    }
                    if (c.buttonBPressed())
                    {
                        Console.WriteLine("Button B pressed!");
                    }
                    if (c.buttonXPressed())
                    {
                        Console.WriteLine("Button X pressed!");
                    }
                    if (c.buttonYPressed())
                    {
                        Console.WriteLine("Button Y pressed!");
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
