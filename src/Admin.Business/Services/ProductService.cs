using Admin.Business.Interfaces;
using Admin.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IVendorRepository _vendorRepository;

        public ProductService(IProductRepository productRepository, IVendorRepository vendorRepository)
        {
            _productRepository = productRepository;
            _vendorRepository = vendorRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }
        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByVendor(Guid vendorId) =>
            await _productRepository.GetProductsByVendor(vendorId);

        public async Task<IEnumerable<Product>> GetProductsVendors() =>
            await _productRepository.GetProductsVendors();

        public async Task<Product> GetProductVendor(Guid id) =>
            await _productRepository.GetProductVendor(id);
    }
}
