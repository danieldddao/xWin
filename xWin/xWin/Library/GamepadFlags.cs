using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Collections;

namespace xWin.Library
{
    public class GamepadFlags
    {
        private Int32 flags;
        
        public GamepadFlags(GamepadButtonFlags f, bool lt0 = false, bool rt0 = false, bool ls0 = false, bool rs0 = false, byte lt = 0, byte rt = 0, byte ls = 0, byte rs = 0, bool x1 = false, bool x2 = false)
        {
            flags = 0;
            lt &= 3;
            rt &= 3;
            ls &= 15;
            rs &= 15;
            byte b0 = ls;
            b0 |= (byte)(rs << 4);
            byte b1 = 0;
            b1 |= (byte)(rt << 6);
            b1 |= (byte)(lt << 4);
            b1 |= (byte)(rs0 ? 8 : 0);
            b1 |= (byte)(ls0 ? 4 : 0);
            b1 |= (byte)(rt0 ? 2 : 0);
            b1 |= (byte)(lt0 ? 1 : 0);

            var ff = BitConverter.GetBytes((short)f);

            var ff2 = new byte[]{ ff[0], ff[1], b1, b0 };
            flags = BitConverter.ToInt32(ff2, 0);
            flags |= x1 ? 1 << 14 : 0;
            flags |= x2 ? 1 << 13 : 0;
        }

        public GamepadFlags(GamepadButtonFlags f, byte lt, byte rt, byte ls, byte rs, bool x1 = false, bool x2 = false) :
        this(f, lt == 0, rt == 0, ls == 0, rs == 0, lt, rt, ls, rs, x1, x2){ }

        public GamepadFlags(Int32 f)
        {
            flags = f;
        }

        public static explicit operator GamepadFlags(Int32 i)
        {
            return new GamepadFlags(i);
        }
                
        public static explicit operator int(GamepadFlags g)
        {
            return g.flags;
        }

        public static bool operator &(GamepadFlags g1, GamepadFlags g2)
        {
            //Check if correct buttons are pressed
            //1048575 = 0x000FFFFF
            if ((g1.flags & g2.flags & 1048575) != (g2.flags & 1048575))          { return false; }

            //Check if Trigger Regions work
            //3145728 = 0x00300000
            if ((g2.flags & 3145728) > 0 && (g1.flags & 3145728) != (g2.flags & 3145728))  { return false; }
            
            //12582912 = 0x00C00000
            if ((g2.flags & 12582912) > 0  && (g1.flags & 12582912) != (g2.flags & 12582912))    { return false; }
            
            //251658240 = 0x0F000000
            if ((g2.flags & 251658240) > 0  && (g1.flags & 251658240) != (g2.flags & 251658240))    { return false; }
            //-268435456 = 0xF0000000
            if ((g2.flags & -268435456) > 0   && (g1.flags & -268435456) != (g2.flags & -268435456))      { return false; }
            
            return true;
        }

        public static bool operator ==(GamepadFlags g1, GamepadFlags g2)
        {
            return g1.flags == g2.flags;
        }
        public static bool operator !=(GamepadFlags g1, GamepadFlags g2)
        {
            return g1.flags != g2.flags;
        }

        public static bool operator ==(int g1, GamepadFlags g2)
        {
            return g1 == g2.flags;
        }
        public static bool operator !=(int g1, GamepadFlags g2)
        {
            return g1 != g2.flags;
        }


        public override string ToString()
        {
            BitArray b = new BitArray(BitConverter.GetBytes(flags));
            String s = "";
            foreach(bool bit in b) { s = (bit ? "1" : "0") + s; }
            return s;
        }
    }
}
