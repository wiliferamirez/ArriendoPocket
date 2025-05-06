using ArriendoPocket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArriendoPocket.Data;

public class ApplicationDbContext : IdentityDbContext<Arrendatario>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Arrendatario> Arrendatarios { get; set; }
    public DbSet<Propiedad> Propiedades { get; set; }

}
