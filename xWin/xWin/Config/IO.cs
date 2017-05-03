using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using System.IO;

namespace xWin.Config
{
    public class IO<T> where T : IMessage<T>, new()
    {
        public const string CONFIGURATION_EXT = ".cfg";
        public const string TYPINGCONTROL_EXT = ".tctrl";
        public const string KEYBOARDSET_EXT = ".chars";
        public List<string> SearchPaths;
        public readonly string ext;
        private MessageParser<T> parser;
        public IO(List<string> paths, string ext)
        {
            SearchPaths = paths;
            this.ext = ext;
            parser = new MessageParser<T>(() => new T());
        }
        
        public T ReadFromFile(string name)
        {
            Console.WriteLine(name);
            if (File.Exists(name))
            {
                using (Stream input = File.OpenRead(name))
                {
                    var c =  parser.ParseFrom(input);
                    return c;
                }
            }
            throw new FileNotFoundException();
    }

        public void WriteToFile(T buffer, string name, string folder="")
        {
            if (folder.Length == 0) { folder = SearchPaths[0]; }
            using (var output = File.Create(folder + "/" + name + ext))
            {
                buffer.WriteTo(output);
            }
        }
    }
}
