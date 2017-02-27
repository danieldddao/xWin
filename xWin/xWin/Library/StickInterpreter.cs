using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWin
{
    //null if not defined
    public class StickInterpreter
    {
        private int angle;
        private int start;
        public StickInterpreter(int arcs, int start=0)
        {
            this.angle = 360 / arcs;
            this.start = start;
        }
        private int? arc(int? check_angle)
        {
            if (check_angle == null)
            {
                return null;
            }

            return check_angle / this.angle;
        }
        public static int? xy2deg(int x, int y) //returns angle in integer degrees or null if undefined
        {
            if (x == 0 && y == 0)
            {
                return null;
            }

            return Convert.ToInt32( Math.Atan2(y, x) * (180.0 / Math.PI) );
        }

        public int? GetRegion(int x, int y)
        {
            return arc(xy2deg(x, y));
        }
    };
}

