using Microsoft.EntityFrameworkCore;
using Ecommerce.Core.Entities;


namespace Ecommerce.Data.Context
{
    public class  AppDbContext : DbContext //AppDbContext hereda de DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Configuración adicional de entidades, restriciones y demás cosas necesarias
        }
    }
}