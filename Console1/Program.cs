using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            
            //int result = calc.Sum(1,2);
            var result = calc.Execute("Sum", new object[] { 1, 2 });
            var result2 = calc.Execute("Raz", new object[] { 3, 1 });
            var result3 = calc.Execute("Pow", new object[] { 3 });
            var result4 = calc.Execute("UmnSum", new object[] { 2, 3, 2 });
          //  var result5 = calc.Execute(Console.ReadLine(), new object[] { 2, 3, 2 });

            Console.WriteLine(string.Format("result Sum = {0}",result));
            Console.WriteLine(string.Format("result Raz = {0}", result2));
            Console.WriteLine(string.Format("result Pow = {0}", result3));
            Console.WriteLine(string.Format("result UmnSum = {0}", result4));
          //  Console.WriteLine(string.Format("result UmnSum = {0}", result5));
            // Console.WriteLine($"(result)");
            Console.ReadKey();
        }
    }
}
