using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Console1;



namespace UnitTestProject1
{
    [TestClass]
    ///<summary>
    ///тестирование Calc
    ///</summary>
    public class UnitTest1
    {
        [TestMethod]

        public void TestMethod1()
        {
            var calc = new Calc();
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3);

        }
    }
}
