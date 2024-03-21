using Microsoft.AspNetCore.Mvc;
using Admin.App.ViewModels;
using Admin.Business.Interfaces;
using AutoMapper;
using Admin.Business.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Admin.App.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,
            IMapper mapper,
            IVendorRepository vendorRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsVendors()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ProductViewModel product = await PopulateVendors(new ProductViewModel());
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await PopulateVendors(productViewModel);
            if (!ModelState.IsValid) return View(productViewModel);

            var imgId = Guid.NewGuid() + "_";
            if (!await UploadArquivo(productViewModel.ImageUpload, imgId)) return View(productViewModel);

            productViewModel.Image = imgId + productViewModel.ImageUpload.FileName;

            await _productRepository.Add(_mapper.Map<Product>(productViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            var updateProduct = await GetProduct(id);
            productViewModel.Vendor = updateProduct.Vendor;
            productViewModel.Image = updateProduct.Image;
            if (!ModelState.IsValid) return View(productViewModel);

            if(productViewModel.ImageUpload != null)
            {
                var imgId = Guid.NewGuid() + "_";
                if (!await UploadArquivo(productViewModel.ImageUpload, imgId)) return View(productViewModel);

                updateProduct.Image = imgId + productViewModel.ImageUpload.FileName;
            }
            updateProduct.Name = productViewModel.Name;
            updateProduct.Description = productViewModel.Description;
            updateProduct.Value = productViewModel.Value;
            updateProduct.Active = productViewModel.Active;

            await _productRepository.Update(_mapper.Map<Product>(updateProduct));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            await _productRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductVendor(id));
            product.Vendors = _mapper.Map<IEnumerable<VendorViewModel>>(await _vendorRepository.GetAll());
            return product;
        }
        private async Task<ProductViewModel> PopulateVendors(ProductViewModel product)
        {
            product.Vendors = _mapper.Map<IEnumerable<VendorViewModel>>(await _vendorRepository.GetAll());
            return product;
        }

        private async Task<bool> UploadArquivo(IFormFile image, string imgId)
        {
            if (image.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imgId + image.FileName);

            if(System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "This file name is already beeing used!");
                return false;
            }

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return true;
        }

        public FileResult DownloadPdf()
        {
            MemoryStream ms = new MemoryStream();
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            byte[] firstString = uniEncoding.GetBytes(
            "Some products are:");
            ms.Write(firstString, 0, firstString.Length);

            return File(ms.ToArray(), "application/pdf", "Products.pdf");
        }
    }
}
