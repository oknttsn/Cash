using Microsoft.AspNetCore.Identity;

namespace Cash.Entity.Concrate;

public class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; } //musterinin ismi
    public string Surname { get; set; } //musterinin ismi 
    public string District { get; set; } // adress
    public string City { get; set; } //sehir
    public string ImageUrl { get; set; } //musteri resim
    public int ConfirmCode { get; set; }
    public List<ClientAccount> ClientAccounts { get; set; }

}
