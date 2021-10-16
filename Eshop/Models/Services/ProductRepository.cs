using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _db;
        public ProductRepository(ShopDbContext db)
        {
            _db = db;
        }
        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products;
        }

        public Product GetProduct(int ID)
        {
            return _db.Products.FirstOrDefault(x => x.ID.Equals(ID));
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
