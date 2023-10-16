using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.Controllers;

public class CustomerLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
