using Admin.Business.Interfaces;
using Admin.Business.Models;
using Admin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AdminDbContext context) : base(context) { }
        public async Task<IEnumerable<Product>> GetProductsByVendor(Guid vendorId)
        {
            return await Search(v => v.VendorId == vendorId);
        }

        public async Task<IEnumerable<Product>> GetProductsVendors()
        {
            return await _dbContext.Products.AsNoTracking().Include(v => v.Vendor).OrderBy(v => v.Name).ToListAsync();
        }

        public async Task<Product> GetProductVendor(Guid id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
