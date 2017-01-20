using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OperationModel
    {
        [DisplayName("Операция")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Arg 1")]
        public int? X { get; set; }

        [DisplayName("Arg 2")]
        public int? Y { get; set; }
        [DisplayName("Arg 3")]
        public int? Z { get; set; }

        public object[] GeParameters()
        {
            var parametrs = new object[] { X, Y, Z };
            return parametrs.Where(p=>p!=null).ToArray();
        }
    }
}