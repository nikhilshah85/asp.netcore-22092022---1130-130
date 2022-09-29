using Microsoft.AspNetCore.Mvc;

namespace shoppingMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}
