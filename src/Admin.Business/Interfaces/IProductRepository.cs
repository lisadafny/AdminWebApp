using Admin.Business.Models;

namespace Admin.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByVendor(Guid vendorId);
        Task<IEnumerable<Product>> GetProductsVendors();
        Task<Product> GetProductVendor(Guid productId);
    }
}
