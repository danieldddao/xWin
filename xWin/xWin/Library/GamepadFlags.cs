using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace xWin.Library
{
    public class GamepadFlags
    {
        private Int32 flags;
        
        public GamepadFlags(GamepadButtonFlags f, bool lt0, bool rt0, bool ls0, bool rs0, bool x1, bool x2, byte lt, byte rt, byte ls, byte rs)
        {
            flags = BitConverter.ToInt32(BitConverter.GetBytes((short)f), 0);
            flags |= lt0 ? Int32.MinValue >> 13 : 0;
            flags |= rt0 ? Int32.MinValue >> 14 : 0;
            flags |= ls0 ? Int32.MinValue >> 16 : 0;
            flags |= rs0 ? Int32.MinValue >> 17 : 0;
            flags |= x1 ? Int32.MinValue >> 18 : 0;
            flags |= x2 ? Int32.MinValue >> 19 : 0;
            flags |= (lt & 240) >> 20;
            flags |= (lt & 240) >> 22;
            flags |= ls >> 24;
            flags |= rs >> 28;
        }

        public GamepadFlags(Int32 f)
        {
            flags = f;
        }

        public GamepadFlags(UInt32 f)
        {
            flags = BitConverter.ToInt32(BitConverter.GetBytes(f),0);
        }

        public static explicit operator GamepadFlags(Int32 i)
        {
            return new GamepadFlags(i);
        }
        public static explicit operator GamepadFlags(UInt32 i)
        {
            return new GamepadFlags(i);
        }
        
        public static explicit operator int(GamepadFlags g)
        {
            return g.flags;
        }

        public static bool operator &(GamepadFlags g1, GamepadFlags g2)
        {
            //-4096 = 0xFFFFF000
            if ((g1.flags & g2.flags & -4096) != (g1.flags & -4096))              { return false; }
            //3072 = 0x00000C00
            if ((g1.flags & 3072) > 0 && (g1.flags & 3072) != (g2.flags & 3072))  { return false; }
            //768 = 0x00000300
            if ((g1.flags & 768) > 0  && (g1.flags & 768) != (g2.flags & 768))    { return false; }
            //240 = 0x000000F0
            if ((g1.flags & 240) > 0  && (g1.flags & 240) != (g2.flags & 240))    { return false; }
            //15 = 0x0000000F
            if ((g1.flags & 15) > 0   && (g1.flags & 15) != (g2.flags & 15))      { return false; }

            return true;
        }
    }
}
