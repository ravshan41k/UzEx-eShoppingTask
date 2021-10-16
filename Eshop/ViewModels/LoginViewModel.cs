using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="INN")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid INN Number.")]
       // [StringLength(9)]
        public string INN { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Eslab qolinsinmi?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; internal set; }
        
    }
}
