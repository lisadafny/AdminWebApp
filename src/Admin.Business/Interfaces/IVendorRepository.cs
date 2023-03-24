using Admin.Business.Models;

namespace Admin.Business.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<Vendor> GetVendorAddress(Guid vendorId);
        Task<Vendor> GetVendorProductsAddress(Guid vendorId);
    }
}
