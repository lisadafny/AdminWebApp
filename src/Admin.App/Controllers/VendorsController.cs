using Microsoft.AspNetCore.Mvc;
using Admin.App.ViewModels;
using Admin.Business.Interfaces;
using AutoMapper;
using Admin.Business.Models;
using Microsoft.AspNetCore.Authorization;

namespace Admin.App.Controllers
{
    [Authorize]
    public class VendorsController : BaseController
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public VendorsController(IVendorRepository vendorRepository, IAddressRepository addressRepository,
        IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VendorViewModel>>(await _vendorRepository.GetAll()));
        }


        public async Task<IActionResult> Details(Guid id)
        {

            var vendorViewModel = await GetVendorAddress(id);

            if (vendorViewModel == null)
            {
                return NotFound();
            }

            return View(vendorViewModel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorViewModel vendorViewModel)
        {
            if (!ModelState.IsValid) return View(vendorViewModel);
            var vendor = _mapper.Map<Vendor>(vendorViewModel);

            await _vendorRepository.Add(vendor);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var vendorViewModel = await GetVendorProductsAddress(id);

            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VendorViewModel vendorViewModel)
        {
            if (id != vendorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(vendorViewModel);


            var vendor = _mapper.Map<Vendor>(vendorViewModel);
            await _vendorRepository.Update(vendor);
            var result = new ReturnViewModel(true, $"Updated {vendor.Name} with success!");
            vendorViewModel.Result = result;
            return View(vendorViewModel);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var vendorViewModel = await GetVendorAddress(id);

            if (vendorViewModel == null)
            {
                return NotFound();
            }

            return View(vendorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vendorViewModel = await GetVendorAddress(id);

            if (vendorViewModel == null) return NotFound();

            await _addressRepository.Delete(vendorViewModel.Address.Id);

            await _vendorRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<VendorViewModel> GetVendorAddress(Guid id)
        {
            return _mapper.Map<VendorViewModel>(await _vendorRepository.GetVendorAddress(id));
        }

        private async Task<VendorViewModel> GetVendorProductsAddress(Guid id)
        {
            return _mapper.Map<VendorViewModel>(await _vendorRepository.GetVendorProductsAddress(id));
        }
    }
}
