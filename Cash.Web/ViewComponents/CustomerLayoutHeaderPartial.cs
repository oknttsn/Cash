using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.ViewComponents;

public class CustomerLayoutHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
