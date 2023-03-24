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
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AdminDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Address> GetAddressByVendor(Guid id)
        {
            return await _dbContext.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.VendorId == id);
        }
    }
}
