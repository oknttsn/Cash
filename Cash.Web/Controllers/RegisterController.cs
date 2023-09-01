using Cash.Dto.AppUserDto;
using Cash.Entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
    {
        if (!ModelState.IsValid) return View();
        AppUser appUser = new AppUser()
        {
            Name = appUserRegisterDto.Name,
            Surname = appUserRegisterDto.SurName,
            Email = appUserRegisterDto.Email,
            City = "adasd",
            District="asd",
            ImageUrl="asd",
        };
        var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
        if (result.Succeeded) return RedirectToAction("Index","ConfirmMail");
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        return View();
    }
}
