using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.Controllers
{
    public class ClientAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
