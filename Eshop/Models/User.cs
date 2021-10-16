using Eshop.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public int INN { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public string Region { get; set; }
    }
}
