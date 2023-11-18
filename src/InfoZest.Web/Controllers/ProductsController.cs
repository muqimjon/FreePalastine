using InfoZest.Service.DTOs.InvalidProducts;
using InfoZest.Service.DTOs.Products;
using InfoZest.Web.Models; 
using Microsoft.AspNetCore.Mvc;
using InfoZest.Web.Models.Products;
using InfoZest.Service.Interfaces.Commons;

namespace InfoZest.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServices services;
        public ProductsController(IServices services)
        {
            this.services = services;
        }

        public async Task<IActionResult> Index()
        {
            var products = await services.ProductService.RetrieveAllAsync();
            var invalidProducts = await services.InvalidProductService.RetrieveAllAsync();

            var invalidProductIds = invalidProducts.Select(m => m.Product.Id).ToList();

            var tengEmasModellar = products.Where(m => !invalidProductIds.Contains(m.Id)).ToList();

            List<ProductViewModel> productViewModels = new();

            foreach(var invalidProduct in invalidProducts)
            {
                var productViewModel = new ProductViewModel
                {
                    Name = invalidProduct.Product.Name,
                    BarCode = invalidProduct.Product.BarCode,
                    Brand = invalidProduct.Product.Brand,
                    Country = invalidProduct.Product.Country,
                    Description = invalidProduct.Product.Description,
                    Info = invalidProduct.Info,
                    IsBoykott = invalidProduct.IsBoycott,
                    IsHaram = invalidProduct.IsHaram,
                    FIleName = invalidProduct.Product.Asset.FileName,

                };
                productViewModels.Add(productViewModel);
            }
            foreach(var model in tengEmasModellar)
            {
                var productViewModel = new ProductViewModel
                {
                    Name = model.Name,
                    BarCode = model.BarCode,
                    Brand = model.Brand,
                    Country = model.Country,
                    Description = model.Description,
                    FIleName = model.Asset.FileName,
                };
                productViewModels.Add(productViewModel);
            }

            return View(productViewModels);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreationModel model, IFormFile file)
        {
            var productCreationDto = new ProductCreationDto
            {
                Name = model.Name,
                BarCode = model.BarCode,
                Brand = model.Brand,
                Country = model.Country,
                Description = model.Description,
                Image = file,
            };

            var productResultDto = await services.ProductService.AddAsync(productCreationDto);

            if (model.IsBoycott is true || model.IsHaram is true)
            {
                var invalidProductCreationDto = new InvalidProductCreationDto
                {
                    IsBoycott = model.IsBoycott,
                    Info = model.Info,
                    IsHaram = model.IsHaram,
                    ProductId = productResultDto.Id
                };

                await services.InvalidProductService.AddAsync(invalidProductCreationDto);
            }
            return Redirect("Index");
        }
    }
}
