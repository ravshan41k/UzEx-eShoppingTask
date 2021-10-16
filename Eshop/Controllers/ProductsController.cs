using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eshop.Models;
using Eshop.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Eshop.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ShopDbContext _context;

        //public ProductsController(ShopDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}

        //// GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// GET: Products/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,Price,Count,Description")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Count,Description")] Product product)
        //{
        //    if (id != product.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        private readonly IProductRepository _product;
        public ProductsController(IProductRepository product)
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


       // [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Product product = _product.GetProduct(id);
            return View(product);
        }
      

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
           
                try
                {
                    _product.UpdateProduct(product);
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

    //private bool ProductExists(int id)
    //    {
    //        return _context.Products.Any(e => e.ID == id);
    //    }
    
}
