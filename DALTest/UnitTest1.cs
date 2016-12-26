using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace DALTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var ctx = new qualitEntities() ) {

                Assert.IsNull(ctx.Set<book>());

            }

        }
    }
}
