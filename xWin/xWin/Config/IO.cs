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
        public List<string> SearchPaths;
        public readonly string ext;
        private MessageParser<T> parser;
        public IO(List<string> paths, string ext)
        {
            SearchPaths = paths;
            this.ext = ext;
            var parser = new MessageParser<T>(() => new T());
        }
        
        public T ReadFromFile(string name)
        {
            foreach (var s in SearchPaths)
            {
                var path = s + "/" + name + ext;
                if (File.Exists(path))
                {
                    using (Stream input = File.OpenRead(path))
                    {
                        return parser.ParseFrom(input);
                    }
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
