using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollPlaza_PrabhDeep.Models
{
    public class TollPrice
    {
        public int ID { get; set; }
        public decimal Charges { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
