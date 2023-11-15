using InfoZest.Service.DTOs.AssetsDto;
using InfoZest.Service.DTOs.InvalidProducts;
using InfoZest.Service.DTOs.Products;
using InfoZest.Service.Interfaces.Commons;
using InfoZest.Service.Services.Commons;
using InfoZest.Web.Models;
using InfoZest.Web.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace InfoZest.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IServices services;
        public ProductsController(IServices services)
        {
            this.services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductCreationModel model, IFormFile file)
        {
            var productCreationDto = new ProductCreationDto
            {
                Name = model.Name,
                BarCode = model.BarCode,
                Brand = model.Brand,
                Country = model.Country,
                Description = model.Description,
                Image = model.formFile,
            };

            var productResultDto = services.ProductService.AddAsync(productCreationDto);

            if(model.IsBoycott is true || model.IsHaram is true) 
            {
                var invalidProductCreationDto = new InvalidProductCreationDto
                {

                }; 
            }
            return View();
        }
    }
}
