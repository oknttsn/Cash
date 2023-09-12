using Cash.Entity.Concrate;
using Cash.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Web.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUser appUser,LoginViewModel loginViewModel)
    {
        var result = await _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, false, true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if(user.EmailConfirmed == true)
                return RedirectToAction("Index", "MyProfile");
        }
        return View();
    }
}
