using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperOperations
{
    public class Therma : IOperation
    {
         public string Name { get { return "RazSum"; } }
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
                return x - y + z;
            }
         }
      
    }
}
