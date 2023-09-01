using Cash.Dto.AppUserDto;
using FluentValidation;

namespace Cash.Business.Validations.AppUserValidator;

public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
        RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Alanı Boş Geçilemez");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola Tekrar Alanı Boş Geçilemez");
        RuleFor(x => x.Name).MaximumLength(30).WithMessage("Maximum 30 Karakter Kullanın");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minimum 2 Karakter Kullanın");
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parola Eşleşmiyor");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz");
    }
}
