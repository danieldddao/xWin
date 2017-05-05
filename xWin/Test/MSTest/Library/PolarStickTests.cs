using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using xWin.Library;
using System.Windows.Forms;
using Moq;
using System.Collections.Generic;

namespace MSTest.Library
{
    [TestClass]
    public class PolarStickTests
    {
        const ushort DEADZONE = 1000;

        [TestInitialize]
        public void Setup()
        {
           
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        /* Test Constructors */
        [TestMethod]
        public void TestXYConstructor()
        {
            for (short x = -32000; x <= 32000; x += 1000)
            {
                for (short y = -32000; y <= 32000; y += 1000)
                {
                    var ps = new PolarStick(x, y, DEADZONE);
                    uint R = (uint)Math.Sqrt(x * x + y * y);
                    short? theta = R > 0 ? (short?)(Math.Atan2(x, y) * 57.2958) : null;
                    if(R < DEADZONE)
                    {
                        Assert.AreEqual(ps.R, (uint)0, String.Format("Deadzone R=0 fail for x={0}, y={1}",x, y));
                        Assert.IsNull(ps.theta, String.Format("Deadzone theta=null fail for x={0}, y={1}", x, y));
                    }
                    else
                    {
                        while (theta < 0) { theta += 360; }
                        while (theta > 359) { theta -= 360; }
                        Assert.AreEqual(ps.R, R, String.Format("Non-Deadzone fail R=calculated R for x={0}, y={1}", x, y));
                        Assert.AreEqual(ps.theta, theta, String.Format("Non-Deadzone fail theta = calculated theta for x={0}, y={1}", x, y));
                    }
                }
            }
        }

        [TestMethod]
        public void TestRTConstructor()
        {
            for (uint r = 0; r < 32000; r+=1000)
            {
                for (short? t = -360; t <= 720; t += 10)
                {
                    var ps = new PolarStick(r, t, DEADZONE);
                    if (r < DEADZONE)
                    {
                        Assert.AreEqual(ps.R, (uint)0, String.Format("Deadzone R=0 fail for r={0}, theta={1}", r, t));
                        Assert.IsNull(ps.theta, String.Format("Deadzone theta=null fail for r={0}, theta={1}", r, t));
                    }
                    else
                    { 
                        var theta = t;
                        while (theta < 0) { theta += 360; }
                        while (theta > 359) { theta -= 360; }
                        Assert.AreEqual(ps.R, r, String.Format("Non-Deadzone R=r fail for r={0}, t={1}", r, t));
                        Assert.AreEqual(ps.theta, theta, String.Format("Non-Deadzone theta=corrected t fail for r={0}, t={1}", r, t));
                    }
                }
            }
        }
    }
}
