using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelSum
{
    public class DelSum : IOperation
    {
        string IOperation.Name { get { return "DelSum"; } }
        object IOperation.Execute(object[] args)
        {
            if (args[3] ==null)
            {
                return "Необходим 4 аргумент";
            }
            else
            {
                var x = Convert.ToInt32(args[0]);
                var y = Convert.ToInt32(args[1]);
                var z = Convert.ToInt32(args[2]);
                var k = Convert.ToInt32(args[3]);
                return x / y + z / k;
            }
        }
    }
    public class Pi : IOperation
    {
        string IOperation.Name
        {
            get
            {
                { return "Pi"; };
            }
        }
        object IOperation.Execute(object[] args)
        {
            return Convert.ToInt32(Math.PI);
        }
    }
}
