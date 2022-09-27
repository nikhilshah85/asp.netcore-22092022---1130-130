using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identity_demo.Controllers
{

    [Authorize]
    public class BankingController : Controller
    {
        [AllowAnonymous] //any1 can access this
        public IActionResult Bankinghome()
        {
            return View();
        }
        [AllowAnonymous] //any1 can access this
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Transfer()
        {
            return View();
        }
        public IActionResult downloadstatement()
        {
            return View();
        }
    }
}
