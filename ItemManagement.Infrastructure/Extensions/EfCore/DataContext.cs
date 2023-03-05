using ItemManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemManagement.Infrastructure.Extensions.EfCore
{
    public class DataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AccessSetting> AccessSettings { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}