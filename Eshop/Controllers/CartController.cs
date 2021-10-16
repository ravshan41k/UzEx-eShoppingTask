using Eshop.Models;
using Eshop.Models.Services;
using Eshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _product;
        public CartController(IProductRepository product)
        {
            _product = product;
        }
        

    }
}
