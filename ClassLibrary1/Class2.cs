using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmnSumOperation
{
    public class UmnSumar : IOperation
    {
        public string Name { get { return "DelSum1"; } }
        public object Execute(object[] args)
        {
            if (args[2]==null)
            {
                return "Необходим 3 аргумент";
            }
            else
            {
                var x = Convert.ToInt32(args[0]);
                var y = Convert.ToInt32(args[1]);
                var z = Convert.ToInt32(args[2]);
                return x + y / z;
            }

        }

    }

    public class SingleOperation : IOperation
    {
        public string Name { get { return "Single"; } }
        public object Execute(object[] args)
        {
            if (args[0] == null)
            {
                return "Необходим 1 аргумент";
            }
            else
            {
                return (int)Math.Pow(Convert.ToInt32(args[0]), 2);
            }
        }

    }
}
