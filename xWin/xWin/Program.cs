using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using xWin.Library;
using SharpDX.XInput;

namespace xWin
{
	class Program
	{
        static void Main(string[] args)
		{
            Thread keyboardThread = new Thread(delegate() {;});
            bool buttonPressA = false;
            bool buttonPressB = false;
            bool buttonPressX = false;
            bool buttonPressY = false;
            XController c = new XController();
            while (true)
            {
                
                if (c.IsConnected())
                {
                    c.UpdateState();
                    /*
                    foreach(var button in c.ButtonsPressed())
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
                    c.MoveCursor();
                    if (c.ButtonsPressed()["A"])
                    {
                        if (!buttonPressA)
                        {
                            buttonPressA = true;
                            c.LeftDown();
                        }
                    }
                    else
                    {
                        if (buttonPressA) c.LeftUp();
                        buttonPressA = false;
                    }
                    if (c.ButtonsPressed()["B"])
                    {
                        if (!buttonPressB)
                        {
                            buttonPressB = true;
                            c.RightDown();
                        }
                    }
                    else
                    {
                        if (buttonPressB) c.RightUp();
                        buttonPressB = false;
                    }
                    if (c.ButtonsPressed()["Y"] && !keyboardThread.IsAlive)
                    {
                        keyboardThread = new Thread(delegate ()
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new KeyboardWindow(c));
                        });
                        keyboardThread.Name = "keyboard";
                        keyboardThread.SetApartmentState(ApartmentState.STA);
                        keyboardThread.Start();
                    }
                    /*if (c.ButtonsPressed()["X"] && keyboardThread.IsAlive)
                    {
                        keyboardThread.Abort();
                    }*/
                    //Thread.Sleep(200);
                    //Console.Clear();
                }
                else
                {
                    Console.WriteLine("Controller Disconnected!");
                }     
            }
		}
	}
}
