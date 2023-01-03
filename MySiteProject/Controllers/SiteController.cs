using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySiteProject.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
