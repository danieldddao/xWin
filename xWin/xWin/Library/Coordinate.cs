using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWin.Library
{
    class Coordinate
    {
        private short xCoord;
        private short yCoord;

        public Coordinate()
        {
            this.xCoord = 0;
            this.yCoord = 0;
        }

        public Coordinate(short xCoord, short yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        public Coordinate(Coordinate coordToCopy)
        {
            this.xCoord = coordToCopy.xCoord;
            this.yCoord = coordToCopy.yCoord;
        }

        public short getXCoordinate()
        {
            return this.xCoord;
        }

        public short getYCoordinate()
        {
            return this.yCoord;
        }

        public short
    }
}
