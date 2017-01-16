using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Console1.Calc;
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

        public void TestSum()
        {
            var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            var result = calc.Execute("Sum", new object[] { 1, 2 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestRaz()
        {
            var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            var result2 = calc.Execute("Raz", new object[] { 3, 1 });
            Assert.AreEqual(result2, 2);
        }
        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            var result3 = calc.Execute("Pow", new object[] { 3 });
            Assert.AreEqual(result3, 27.0);
        }
        [TestMethod]
        public void TestUmnSum()
        {
            var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            var result4 = calc.Execute("UmnSum", new object[] { 2, 3, 2 });
            Assert.AreEqual(result4, 8);
        }
    }

}
