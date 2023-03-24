using Admin.Business.Models;

namespace Admin.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByVendor(Guid id);
    }
}
