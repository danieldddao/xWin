using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Extensions.Forms;
using xWin.Forms;

namespace NUnitForms
{
    [TestClass]
    public class UnitTest1
    {
        xWinPanel xWinPanel;

        [TestInitialize]
        public void Setup()
        {
            xWinPanel = new xWinPanel();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
