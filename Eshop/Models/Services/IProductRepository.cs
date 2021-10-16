using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Services
{
  public  interface IProductRepository
    {
        Product GetProduct(int ID);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
