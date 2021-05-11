using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Customer
    {
        public string Name { get; set; }

        public decimal Income { get; set; }

        public EnumTypePerson TypePerson { get; set; }

        public string CustomerCode { get; set; }

        public DateTime CustomerSince { get; set; }
    }
}
