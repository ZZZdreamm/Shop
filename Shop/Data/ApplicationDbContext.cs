using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Shop.Models.ItemModel>? ItemModel { get; set; }
        public DbSet<Shop.Models.CustomerModel>? CustomerModel { get; set; }
    }
}