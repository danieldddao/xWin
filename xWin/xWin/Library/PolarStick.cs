using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWin.Wrapper;

namespace xWin.Library
{
    public interface IPolarSticks
    {

    }
    public struct PolarStick : IPolarSticks
    {
        ushort deadzone;// { get; private set; }
        uint _R;
        public uint R
        {
            get { return _R; }
            set
            {
                //var r = (uint)Math.Abs(value);
                _R = value < deadzone ? 0 : value;
            }
        }
        //values 0 to 359
        short? _theta;
        public short? theta
        {
            get
            {
                if (R == 0) { return null; }
                return _theta;
            }
            set
            {
                _theta = (short?)(value % 360);
                _theta +=(short?) ( _theta < 0 ? 360 : 0);
            }
        }

        //public short? getTheta() { return theta; }
        //public uint getR() { return R; }
        public PolarStick(uint r, short? t, ushort deadzone)
        {
            this.deadzone = deadzone;
            _R = r < deadzone ? 0 : r;
            _theta = (short?)(t % 360);
            _theta += (short?)((_theta < 0) ? 360 : 0);
        }
        public PolarStick(short x, short y, ushort deadzone)
        {
            this.deadzone = deadzone;
            _R = (uint)Math.Sqrt(x * x + y * y);
            _R = _R < deadzone ? 0 :_R;
            _theta = (_R == 0) ? null : (short?)(Math.Atan2(x, y) * 57.2958);
            _theta += (short?)((_theta < 0) ? 360 : 0);
        }
    }
}
