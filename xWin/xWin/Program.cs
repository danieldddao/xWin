﻿using System;
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
            XController c = new XController();
            bool msg = false;
            while(!Console.KeyAvailable)
            {
                //Thread.Sleep(200);
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
                    }*/
                    c.MoveCurser();
                    
                    //Console.WriteLine("Mouse x: " + Cursor.Position.X);
                    //Console.WriteLine("Mouse y: " + Cursor.Position.Y);
                    Console.Clear();
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
