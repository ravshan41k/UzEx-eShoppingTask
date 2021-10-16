using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.ViewModels
{
    public class CreateProductViewModel
    {
       
        [Required(ErrorMessage = "Please,Enter product name!")]
        [Display(Name = "Product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please,Enter product price!")]
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please,Enter product count!")]
        [Display(Name = "Count")]
        [MinLength(1)]
        public int Count { get; set; }
        [Required(ErrorMessage ="Please,Write product description!")]
        public string Description { get; set; }
    }
}
