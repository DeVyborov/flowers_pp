using Microsoft.VisualStudio.TestTools.UnitTesting;
using flowers_pp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_pp.Tests
{
    [TestClass()]
    public class OrderWindowTests
    {
        public int CalcFinalSumm(int price, int discount)
        {
            return price - ((price / 100) * discount);
        }

        [TestMethod()]
        public void CalcFinalSummTest()
        {
            Assert.AreEqual(CalcFinalSumm(500, 50), 250);
        }
    }
}