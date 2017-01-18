using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console1
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            return (int)Execute("Sum", new object[] { x, y });
            //return x + y;
        }

        public Calc(IEnumerable<IOperation> opers)
        {
            operations = opers;
        }

        public Calc(IOperation[] opers)
        {
            operations = opers;
        }


        private IEnumerable<IOperation> operations {get; set;}
        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o =>  o.Name.ToUpper() == name.ToUpper() );
            
            if (oper == null)
                return $"IOperation {name} not found";
            return oper.Execute(args);
        }

        public IEnumerable<string> GetOperationNames()
        {
            return operations.Select(o => o.Name);

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
            if (args[1] == null)
            {

                return "Необходим 2 аргумент";
            }
            else
            {
                var x = Convert.ToInt32(args[0]);
                var y = Convert.ToInt32(args[1]);
                return x + y;
            }
        }
    }

    public class RazOperation : IOperation
    {
        public string Name { get { return "Raz"; } }
        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) - Convert.ToInt32(args[1]);
        }
    }

    public class PowOperation : IOperation
    {
        public string Name { get { return "Pow"; } }
        public object Execute(object[] args)
        {
            if (args[0] == null)
            {

                return "Необходим 1 аргумент";
            }
            else
            {
                return Math.Pow(Convert.ToInt32(args[0]), 3);
            }
        }
    }

    public class UmnsumOperation : IOperation
    {
        public string Name { get { return "UmnSum"; } }
        public object Execute(object[] args)
        {
            
            if (args[2] == null)
            {
               
                return "Необходим 3 аргумент";
            }
            else
            {
                var x = Convert.ToInt32(args[0]);
                var y = Convert.ToInt32(args[1]);
                var z = Convert.ToInt32(args[2]);
                return x + y * z;
            }
        }
    }
}
