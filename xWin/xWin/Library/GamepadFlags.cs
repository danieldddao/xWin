using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Collections;

namespace xWin.Library
{
    public struct GamepadFlags
    {
        private Int32 flags;

        private static int BUTTONMASK = 0x000FFFFF;
        private static int LTMASK = 0x00300000;
        private static int RTMASK = 0x00C00000;
        private static int LSMASK = 0x0F000000;
        private static int RSMASK = -268435456;


        /*Should be used when defining states*/
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

        /*Should be used with controller reads*/
        public GamepadFlags(GamepadButtonFlags f, byte lt, byte rt, byte ls, byte rs, bool x1 = false, bool x2 = false) :
        this(f, lt == 0, rt == 0, ls == 0, rs == 0, lt, rt, ls, rs, x1, x2){ }

        public GamepadFlags(Int32 f)
        {
            flags = f;
        }
        
        public static GamepadFlags operator ~(GamepadFlags g)
        {
            return new GamepadFlags(~g.flags);
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
            if ((g1.flags & g2.flags & BUTTONMASK) != (g2.flags & BUTTONMASK))              { return false; }

            //Check if Trigger Regions work
            //3145728 = 0x00300000
            if ((g2.flags & RTMASK) != 0 && ((g1.flags & RTMASK) != (g2.flags & RTMASK)) )  { return false; }
            
            //12582912 = 0x00C00000
            if ((g2.flags & LTMASK) != 0  && ((g1.flags & LTMASK) != (g2.flags & LTMASK))  ){ return false; }
            
            //251658240 = 0x0F000000
            if ((g2.flags & RSMASK) != 0  && ((g1.flags & RSMASK) != (g2.flags & RSMASK)) ) { return false; }
            //-268435456 = 0xF0000000
            if ((g2.flags & LSMASK) != 0  && ((g1.flags & LSMASK) != (g2.flags & LSMASK)) ) { return false; }
            
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

        public static bool operator ==(GamepadFlags g2, int g1)
        {
            return g1 == g2.flags;
        }
        public static bool operator !=(GamepadFlags g2, int g1)
        {
            return g1 != g2.flags;
        }
        
        /*for applying masks*/
        public static GamepadFlags operator *(GamepadFlags g1, GamepadFlags g2)
        {
            Int32 f = g1.flags & g2.flags & BUTTONMASK;
            f += ((g1.flags & g2.flags & RTMASK) == (g1.flags & RTMASK)) ? g1.flags & RTMASK : 0;
            f += ((g1.flags & g2.flags & LTMASK) == (g1.flags & LTMASK)) ? g1.flags & LTMASK : 0;
            f += ((g1.flags & g2.flags & RSMASK) == (g1.flags & RSMASK)) ? g1.flags & RSMASK : 0;
            f += ((g1.flags & g2.flags & LSMASK) == (g1.flags & LSMASK)) ? g1.flags & LSMASK : 0;
            return new GamepadFlags(f);
        }

        /*for creating masks*/
        public static GamepadFlags operator |(GamepadFlags g1, GamepadFlags g2)
        {
            var q = g1.flags | g2.flags;
            Int32 f = q & BUTTONMASK;
            f += ((q & RTMASK) != 0) ? RTMASK : 0;
            f += ((q & LTMASK) != 0) ? LTMASK : 0;
            f += ((q & RSMASK) != 0) ? RSMASK : 0;
            f += ((q & LSMASK) != 0) ? LSMASK : 0;
            return new GamepadFlags(f);
        }

        public override string ToString()
        {
            BitArray b = new BitArray(BitConverter.GetBytes(flags));
            String s = "";
            foreach(bool bit in b) { s = (bit ? "1" : "0") + s; }
            return s;
        }

        public string SpecialString()
        {
            string str = "";
            GamepadButtonFlags g = (GamepadButtonFlags)((short)(flags & 0x0000FFFF));
            foreach (GamepadButtonFlags k in Enum.GetValues(typeof(GamepadButtonFlags)))
            {
                if (k == GamepadButtonFlags.None)
                    continue;
                if (g.HasFlag(k))
                    str += k.ToString() + ",";
            }
            byte b = (byte)((flags & 0x000F0000) >> 16);
            if ((b & 1) != 0)
                str += "LeftTriggerReleased,";
            if ((b & 2) != 0)
                str += "RightTriggerReleased,";
            if ((b & 4) != 0)
                str += "LeftStickCenter,";
            if ((b & 8) != 0)
                str += "RightStickCenter,";

            b = (byte)((flags & LTMASK) >> 20);
            if (b != 0)
            {
                str += "LeftTrigger" + b.ToString() + ",";
            }
            b = (byte)((flags & RTMASK) >> 22);
            if(b != 0)
            {
                str += "RightTrigger" + b.ToString() + ",";
            }
            b = (byte)((flags & LSMASK) >> 24);
            if (b != 0)
            {
                str += "LeftSitck" + b.ToString() + ",";
            }
            b = (byte)((flags & RSMASK) >> 28);
            if (b != 0)
            {
                str += "RightSitck" + b.ToString() + ",";
            }
            return str.TrimEnd(',');
        }
    }
}
