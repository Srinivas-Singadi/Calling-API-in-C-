using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingWebApi.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string customName { get; set; }

        public IList<Hardware> hardware  { get; set; }
        public IList<Software> software { get; set; }

    }
}
