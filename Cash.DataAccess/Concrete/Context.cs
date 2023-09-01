using Cash.Entity.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cash.DataAccess.Concrate;

public class Context : IdentityDbContext<AppUser,AppRole,Guid>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-QCP3Q3R; database=Cash; integrated security=true;TrustServerCertificate = True;");
    }
    public DbSet<ClientAccount> ClientAccounts { get; set; }
    public DbSet<AccountProcess> AccountProcesses { get; set; }
}
