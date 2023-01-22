
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZayWebSite.Models;

namespace ZayWebSite.Context
{
    public class ZayDbContext:IdentityDbContext<AppUser>
    {
        public ZayDbContext(DbContextOptions options) : base(options) {}
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<CategoriesMonth> CategoriesMonths { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ServiceSec> ServiceSec { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
