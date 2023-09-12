using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.Controllers;

public class MyProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
