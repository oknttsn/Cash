using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.ViewComponents;

public class CustomerLayoutScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
