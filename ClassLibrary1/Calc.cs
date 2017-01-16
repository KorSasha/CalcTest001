using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            return (int)Execute("Sum", new object[] { x, y });
            //return x + y;
        }

        public Calc(IOperation[] opers)
        {
            operations = opers;
        }

     
        private IOperation[] operations {get; set;}
        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            return oper.Execute(args);
        }
    }

    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);

    }

    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] + (int)args[1];
        }
    }

    public class RazOperation : IOperation
    {
        public string Name { get { return "Raz"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] - (int)args[1];
        }
    }

    public class PowOperation : IOperation
    {
        public string Name { get { return "Pow"; } }
        public object Execute(object[] args)
        {
            return Math.Pow((int)args[0], 3);
        }
    }

    public class UmnsumOperation : IOperation
    {
        public string Name { get { return "UmnSum"; } }
        public object Execute(object[] args)
        {
            return (int)args[0] + (int)args[1] * (int)args[2];
        }
    }
}
