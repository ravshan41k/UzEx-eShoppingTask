using Eshop.Models;
using Eshop.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository _product;
        public HomeController(IProductRepository product)
        {
            _product = product;
        }
        
        public ActionResult Index()
        {
            IEnumerable<Product> products = _product.GetAllProducts();
            return View(products);
        }
        [HttpGet]
      public IActionResult Index(string searchstring = null)
        {
            ViewData["GetCategoryDetails"] = searchstring;
            IEnumerable<Product> products;
            if (!string.IsNullOrEmpty(searchstring))
            {
                products = _product.GetAllProducts().Where(s => s.Name.ToLower().Contains(searchstring.ToLower()));
            }
            else
            {
                products = _product.GetAllProducts();
            }

            return View("Index", products);
        }

      
        public ActionResult Details()
        {
            return View();
        }
        [HttpGet]
       // [Authorize(Roles = "admin")]
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                _product.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }


        }


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Product product = _product.GetProduct(id);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _product.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            _product.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
