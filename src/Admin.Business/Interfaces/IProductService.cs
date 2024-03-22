using Admin.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByVendor(Guid vendorId);
        Task<IEnumerable<Product>> GetProductsVendors();
        Task<Product> GetProductVendor(Guid id);

        Task Add(Product product);

        Task Update(Product product);

        Task Delete(Guid id);
    }
}
