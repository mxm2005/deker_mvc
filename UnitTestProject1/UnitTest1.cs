using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(20 > 10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var lst = RecommendProduct.Instance.GetRecommendProd();
            Assert.IsTrue(lst != null && lst.Count > 0);
        }
    }
}
