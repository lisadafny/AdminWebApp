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
        private readonly IVendorService _vendorService;
        private readonly IMapper _mapper;
        public VendorsController(IVendorService vendorService, IMapper mapper)
        {
            _vendorService = vendorService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VendorViewModel>>(await _vendorService.GetAll()));
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

            await _vendorService.Add(vendor);
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
            await _vendorService.Update(vendor);
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

            await _vendorService.Delete(id, vendorViewModel.Address.Id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<VendorViewModel> GetVendorAddress(Guid id)
        {
            return _mapper.Map<VendorViewModel>(await _vendorService.GetVendorAddress(id));
        }

        private async Task<VendorViewModel> GetVendorProductsAddress(Guid id)
        {
            return _mapper.Map<VendorViewModel>(await _vendorService.GetVendorProductsAddress(id));
        }
    }
}
