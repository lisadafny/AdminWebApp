using Microsoft.AspNetCore.Mvc;
using Admin.App.ViewModels;
using Admin.Business.Interfaces;
using AutoMapper;
using Admin.Business.Models;

namespace Admin.App.Controllers
{
    public class VendorsController : BaseController
    {
        public IVendorRepository _vendorRepository { get; set; }
        private readonly IMapper _mapper;
        public VendorsController(IVendorRepository vendorRepository,
            IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<VendorViewModel>>(await _vendorRepository.GetAll()));
        }


        public async Task<IActionResult> Details(Guid id)
        {

            var vendorViewModel = GetVendorAddress(id);

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
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var vendorViewModel = GetVendorAddress(id);

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
            var vendorViewModel = GetVendorAddress(id);

            if (vendorViewModel == null) return NotFound();

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
