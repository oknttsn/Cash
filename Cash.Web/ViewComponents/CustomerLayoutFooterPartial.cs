using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.ViewComponents;

public class CustomerLayoutFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
