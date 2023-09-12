using Cash.Dto.AppUserDto;
using Cash.Entity.Concrate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
        Random random = new Random();
        AppUser appUser = new AppUser()
        {
            Name = appUserRegisterDto.Name,
            Surname = appUserRegisterDto.SurName,
            UserName = random.ToString(),
            Email = appUserRegisterDto.Email,
            City = "adasd",
            District="asd",
            ImageUrl="asd",
            ConfirmCode=random.Next(1000,9999)
        };
        var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
        if (result.Succeeded)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Cash Admin","okan.ttsn@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
            mimeMessage.From.Add(mailboxAddress);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Kayit Islemini Gerceklestirmek Icin Kodunuz :" + appUser.ConfirmCode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Cash Confrim Code";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("okan.ttsn@gmail.com", "itqpbpfedcsrrqbl");
            client.Send(mimeMessage);
            client.Disconnect(true);

            TempData["Mail"] = appUserRegisterDto.Email;
			return RedirectToAction("Index", "ConfirmMail");
		}
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
