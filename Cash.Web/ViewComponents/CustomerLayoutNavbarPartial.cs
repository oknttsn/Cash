using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.ViewComponents;

public class CustomerLayoutNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
