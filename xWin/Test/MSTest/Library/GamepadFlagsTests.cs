using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using xWin.Config;
using SharpDX.XInput;
using System.Windows.Forms;

namespace MSTest.Library
{
    [TestClass]
    public class GamepadFlagsTests
    {
        GamepadFlags ABflags, Aflags, Bflags, mask;
        GamepadFlags RTR1flags, LTR1flags, LTRTR1flags, triggermask;
        GamepadFlags RSR1flags, LSR1flags, LSRSR1flags;
        GamepadFlags ALTR1flags;
        [TestInitialize]
        public void Setup()
        {

            var g1 = new GamepadButtonFlags();
            g1 |= GamepadButtonFlags.A;
            g1 |= GamepadButtonFlags.B;

            var g2 = new GamepadButtonFlags();
            g2 |= GamepadButtonFlags.A;

            var g3 = new GamepadButtonFlags();
            g3 |= GamepadButtonFlags.B;

            ABflags = new GamepadFlags(g1);
            Aflags = new GamepadFlags(g2);
            Bflags = new GamepadFlags(g3);

            LTR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 1);
            RTR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 1);
            LTRTR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 1, 1);

            triggermask = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 3, 3);

            LSR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 1);
            RSR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 0, 1);
            LSRSR1flags = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 1, 1);

            ALTR1flags = new GamepadFlags(GamepadButtonFlags.A, false, false, false, false, 1);

            mask = new GamepadFlags(-1);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        //all bits from the flags are in the same place
        public void GamepadButtonFlagsBitEquivalenceTest()
        {
            for (var i = 0; i < 14; ++i)
            {
                var g1 = new GamepadFlags((GamepadButtonFlags)(1 << i));
                Assert.AreEqual(1 << i, (int)g1);
            }
            unchecked
            {
                var g2 = new GamepadFlags((GamepadButtonFlags.Y));
                Assert.AreEqual(1 << 15, (int)g2);
            }
        }

        [TestMethod]
        public void x1x2Test()
        {
            //x1 flag
            var g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 0, 0, true);
            Assert.AreEqual(1 << 14, (int)g1);
            //21 flag
            g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 0, 0, false, true);
            Assert.AreEqual(1 << 13, (int)g1);
        }

        [TestMethod]
        public void lt0rt0ls0rs0Test()
        {
            var g1 = new GamepadFlags(GamepadButtonFlags.None, true);
            Assert.AreEqual(1 << 16, (int)g1);
            g1 = new GamepadFlags(GamepadButtonFlags.None, false, true);
            Assert.AreEqual(1 << 17, (int)g1);
            g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, true);
            Assert.AreEqual(1 << 18, (int)g1);
            g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, true);
            Assert.AreEqual(1 << 19, (int)g1);
        }

        [TestMethod]
        public void ltrtTest()
        {
            for (byte i = 255; i > 0; i--)
            {
                var g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, i);
                Assert.AreEqual((i & 3) << 20, (int)g1);
            }
            for (byte i = 255; i > 0; i--)
            {
                var g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, i);
                Assert.AreEqual((i & 3) << 22, (int)g1);
            }
            for (byte i = 255; i > 0; i--)
            {
                var g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, i);
                Assert.AreEqual((i & 15) << 24, (int)g1);
            }
            for (byte i = 255; i > 0; i--)
            {
                var g1 = new GamepadFlags(GamepadButtonFlags.None, false, false, false, false, 0, 0, 0, i);
                Assert.AreEqual((i & 15) << 28, (int)g1);
            }
        }

        [TestMethod]
        public void All1Test()
        {//-24577 is 0b1001111111111111, all gamepadbuttonflags set
            var g1 = new GamepadFlags((GamepadButtonFlags)(short)-24577, true, true, true, true, 3, 3, 15, 15, true, true);
            Assert.AreEqual(-1, (int)g1);
        }

        [TestMethod]
        public void ANDopButtonsTest()
        {
            Assert.IsFalse(Aflags & ABflags);
            Assert.IsFalse(Bflags & ABflags);
            Assert.IsFalse(Bflags & Aflags);
            Assert.IsFalse(Aflags & Bflags);
            Assert.IsTrue(Aflags & Aflags);
            Assert.IsTrue(Bflags & Bflags);
            Assert.IsTrue(ABflags & ABflags);
            Assert.IsTrue(ABflags & Aflags);
            Assert.IsTrue(ABflags & Bflags);
        }

        [TestMethod]
        public void ANDopTriggerRegionsTest()
        {
            Assert.IsFalse(LTR1flags & LTRTR1flags);
            Assert.IsFalse(RTR1flags & LTRTR1flags);
            Assert.IsFalse(RTR1flags & LTR1flags);
            Assert.IsFalse(LTR1flags & RTR1flags);
            Assert.IsTrue(RTR1flags & RTR1flags);
            Assert.IsTrue(LTR1flags & LTR1flags);
            Assert.IsTrue(LTRTR1flags & LTRTR1flags);
            Assert.IsTrue(LTRTR1flags & RTR1flags);
            Assert.IsTrue(LTRTR1flags & RTR1flags);
        }

        [TestMethod]
        public void ANDopStickRegionsTest()
        {

            Assert.IsFalse(LSR1flags & LSRSR1flags);
            Assert.IsFalse(RSR1flags & LSRSR1flags);
            Assert.IsFalse(RSR1flags & LSR1flags);
            Assert.IsFalse(LSR1flags & RSR1flags);
            Assert.IsTrue(RSR1flags & RSR1flags);
            Assert.IsTrue(LSR1flags & LSR1flags);
            Assert.IsTrue(LSRSR1flags & LSRSR1flags);
            Assert.IsTrue(LSRSR1flags & RSR1flags);
            Assert.IsTrue(LSRSR1flags & RSR1flags);
        }

        [TestMethod]
        public void ANDopButtonsAndRegionsTest()
        {
            Assert.IsTrue(ALTR1flags & Aflags);
            Assert.IsTrue(ALTR1flags & LTR1flags);
            Assert.IsFalse(Aflags & ALTR1flags);
            Assert.IsFalse(LTR1flags & ALTR1flags);
        }

        [TestMethod]
        public void SimplifiedConstructorTest()
        {
            var g = new GamepadFlags(0, 0, 0, 0, 0);
            Assert.AreEqual(983040, (int)g, string.Format("{0} {1}", (GamepadFlags)983040, g));
            g = new GamepadFlags(0, 1, 0, 1, 1);
            Assert.AreEqual(286392320, (int)g, string.Format("\n\n{0} \n{1}", (GamepadFlags)286392320, g));
        }


        [TestMethod]
        public void ORopButtonsTest()
        {
            Assert.AreEqual((int)(Aflags | Aflags), (int)Aflags);
            Assert.AreEqual((int)(Aflags | Bflags), (int)ABflags);
            Assert.AreEqual((int)(Bflags | Aflags), (int)ABflags);
            Assert.AreEqual((int)(Bflags | ABflags), (int)ABflags);
            Assert.AreEqual((int)(Aflags | ABflags), (int)ABflags);
            Assert.AreEqual((int)(ABflags | Aflags), (int)ABflags);
            Assert.AreEqual((int)(ABflags | Bflags), (int)ABflags);
        }

        [TestMethod]
        public void ORopTriggerRegionsTest()
        {
            Assert.AreEqual((int)(LTR1flags | RTR1flags), (int)triggermask);
            Assert.AreEqual((int)(LTR1flags | LTRTR1flags), (int)triggermask);
            Assert.AreEqual((int)(RTR1flags | LTRTR1flags), (int)triggermask);
            Assert.AreEqual((int)(RTR1flags | LTR1flags), (int)triggermask);
            Assert.AreEqual((int)(LTRTR1flags | LTR1flags), (int)triggermask);
            Assert.AreEqual((int)(LTRTR1flags | RTR1flags), (int)triggermask);
        }
        
        [TestMethod]
        public void STARopTest()
        {
            Assert.AreEqual((int)(Aflags * mask), (int)Aflags);
            Assert.AreEqual((int)(LTR1flags * mask), (int)LTR1flags);
            Assert.AreEqual((int)(RTR1flags * mask), (int)RTR1flags);
            Assert.AreEqual((int)(LSR1flags * mask), (int)LSR1flags);
            Assert.AreEqual((int)(RSR1flags * mask), (int)RSR1flags);
        }
    }
}