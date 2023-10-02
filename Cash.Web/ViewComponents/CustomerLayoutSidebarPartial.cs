using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.ViewComponents;

public class CustomerLayoutSidebarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
