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
            if (args.Count()<3)
            { 
                return 0;
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

    public class UmnSum : IOperation
    {
        public string Name { get { return "Single"; } }
        public object Execute(object[] args)
        {
            if (args[0] == null)
            {
                return 0;
            }
            else
            {
                return (int)Math.Pow(Convert.ToInt32(args[0]), 2);
            }
        }

    }
}
