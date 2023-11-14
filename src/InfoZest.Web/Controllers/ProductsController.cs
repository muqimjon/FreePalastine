using Microsoft.AspNetCore.Mvc;

namespace InfoZest.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
