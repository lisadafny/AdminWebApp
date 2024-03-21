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
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(AdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Vendor>> GetAll() 
        {
            return await _dbContext.Vendors.AsNoTracking().Include(x => x.Products).AsNoTracking().ToListAsync();
        }

        public async Task<Vendor> GetVendorAddress(Guid id)
        {
            return await _dbContext.Vendors.AsNoTracking().Include(v => v.Address).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vendor> GetVendorProductsAddress(Guid id)
        {
            return await _dbContext.Vendors.AsNoTracking()
                .Include(v => v.Products)
                .Include(v => v.Address)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
