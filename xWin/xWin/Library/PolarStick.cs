using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWin.Library
{
  public struct PolarStick
  {
    public ushort deadzone { get; private set; }
    public uint R 
    {
      get { return R; }
      set {
        R = (uint)Math.Abs(value);
        if ( R < deadzone ) { R = 0; }
        if (R == 0) { theta = null; }
      }
    }
    //values 0 to 359
    public short? theta
    {
      get { return theta; }
      set
      {
        if (R == 0) { theta = null; }
        else
        {
          theta = (short?)(value % 360);
          theta += (short?)((theta < 0) ? 360 : 0);
        }
      }
    }

    public PolarStick(uint R, short? theta, ushort deadzone = 0)
    {
      this.deadzone = deadzone;
      this.R = R;
      this.theta = theta;
    }
    public PolarStick(short x, short y, ushort deadzone = 0)
    {
      this.deadzone = deadzone;
      R = (uint)Math.Sqrt(x * x + y * y);
      theta = (short?)(Math.Atan2(x, y) * 57.2958);
    }
  }
}
