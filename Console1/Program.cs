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
            var calc = new Calc();
            int result = calc.Sum(1,2);
            Console.WriteLine(string.Format(" result = {0}",result));
           // Console.WriteLine($"(result)");
            Console.ReadKey();
        }
    }
}
