using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using static Configuration.Types;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "../../../mouse_config.dat";
            Configuration config1 = new Configuration
            {
                MouseControl = new Stick { S = ControllerSticks.Leftstick, Threshold = .5F, MoveMouse = true },
                InvertLRMouse = false,
                InvertUDMouse = false,
                Sensitivity = .5F,
                LeftClick = ControllerButton.A,
                RightClick = ControllerButton.B
            };
            using (Stream output = File.OpenWrite( file ))
            {
                config1.WriteTo(output);
            }
            Configuration config_in;
            using (Stream input = File.OpenRead(file))
            {
                config_in = Configuration.Parser.ParseFrom(input);
            }
            Console.WriteLine(config_in.InvertLRMouse);
            Console.WriteLine(config_in.InvertUDMouse);
            Console.WriteLine(config_in.LeftClick);
            Console.WriteLine(config_in.RightClick);
            Console.WriteLine(config_in.Sensitivity);
        }
    }
}
