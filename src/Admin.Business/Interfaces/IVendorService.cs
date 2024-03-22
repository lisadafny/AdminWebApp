using Admin.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Business.Interfaces
{
    public interface IVendorService
    {
        Task<Vendor> GetVendorAddress(Guid id);
        Task<IEnumerable<Vendor>> GetAll();
        Task<Vendor> GetVendorProductsAddress(Guid id);

        Task Add(Vendor vendor);

        Task Update(Vendor vendor);

        Task Delete(Guid vendorId, Guid addressId);
        
    }
}
