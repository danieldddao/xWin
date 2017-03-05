using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWin.Library
{
    public interface IXController
    {
        void UpdateState();
        Dictionary<string, bool> ButtonsPressed();
        Dictionary<string, short> GetLeftCart();
        Dictionary<string, double> GetLeftPolar();
        Dictionary<string, short> GetRightCart();
        Dictionary<string, double> GetRightPolar();
        short GetLeftTrigger();
        short GetRightTrigger();
        void MoveCursor();
        bool IsConnected();
        void LeftClick();
        void LeftDown();
        void LeftUp();
        void RightClick();
        void RightDown();
        void RightUp();
    }
}
