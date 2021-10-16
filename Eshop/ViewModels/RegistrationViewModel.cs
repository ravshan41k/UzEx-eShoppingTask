using Eshop.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="Please,Enter your Full Name!")]
        [Display(Name ="F.I.O")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please,Enter Inn code")]
        [Display(Name ="INN")]
        
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid INN Number")]
        public int INN { get; set; }
        [Required(ErrorMessage ="Choose this item")]
        
        public string Type { get; set; }
        [Required(ErrorMessage ="Please,Enter your address!")]
        public string Adress { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Please,Enter your e-mail!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Please,Enter your Phone Number!")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Please, Choose your region")]
        
         public string Region { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password did not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}
