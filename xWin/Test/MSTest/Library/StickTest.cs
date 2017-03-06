using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using xWin;
using Moq;

namespace MSTest.Library
{
  [TestClass]
  public class StickTest
  {
    StickInterpreter sticks;
    [TestInitialize]
    public void Setup()
    {
      sticks = new StickInterpreter(8);
    }

    [TestMethod] //correctly get region from x,y location
    public void TestStickRegions()
    {
      int correct = 0;
      if (sticks.GetRegion( 1000,     0) == 0) correct++;
      if (sticks.GetRegion( 1000,  1000) == 1) correct++;
      if (sticks.GetRegion(    0,  1000) == 2) correct++;
      if (sticks.GetRegion(-1000,  1000) == 3) correct++;
      if (sticks.GetRegion(-1000,     0) == 4) correct++;
      if (sticks.GetRegion(-1000, -1000) == 5) correct++;
      if (sticks.GetRegion(    0, -1000) == 6) correct++;
      if (sticks.GetRegion( 1000, -1000) == 7) correct++;

      Assert.IsTrue(correct == 8);
    }

    [TestMethod]//correctly get null from 0,0 location
    public void TestCenter()
    {
      Assert.IsNull(sticks.GetRegion(0,0));


    }
  }
}