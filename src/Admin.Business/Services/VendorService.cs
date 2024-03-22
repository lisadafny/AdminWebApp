using Admin.Business.Interfaces;
using Admin.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Business.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IAddressRepository _addressRepository;
        public VendorService(IVendorRepository vendorRepository, IAddressRepository addressRepository)
        {
            _vendorRepository = vendorRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Vendor vendor)
        {
            await _vendorRepository.Add(vendor);
        }

        public async Task Update(Vendor vendor)
        {
            await _vendorRepository.Update(vendor);
        }

        public async Task Delete(Guid vendorId, Guid addressId)
        {
            await _addressRepository.Delete(addressId);

            await _vendorRepository.Delete(vendorId);
        }

        public async Task<Vendor> GetVendorAddress(Guid id) =>    
            await _vendorRepository.GetVendorAddress(id);

        public async Task<IEnumerable<Vendor>> GetAll() =>
            await _vendorRepository.GetAll();

        public async Task<Vendor> GetVendorProductsAddress(Guid id) =>
            await _vendorRepository.GetVendorProductsAddress(id);
    }
}
