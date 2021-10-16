using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Order
    {
        public int ID { get; set; }
       public int ProductID { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
