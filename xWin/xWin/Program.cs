﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using xWin.Library;
using SharpDX.XInput;

namespace xWin
{
	class Program
	{
		static void Main(string[] args)
		{
            XController c = new XController(new SharpDX.XInput.Controller(UserIndex.One));
            bool msg = false;
            while(!Console.KeyAvailable)
            {
                //Thread.Sleep(200);
                if (c.IsConnected())
                {
                    c.UpdateSate();
                    foreach(var button in c.ButtonsPressed())
                    {
                        Console.WriteLine(button.Key + " is pressed: " + button.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Controller Disconnected!");
                    msg = false;
                }     
            }
		}
	}
}
