using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Product
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
       
        public int Price { get; set; }
       
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
