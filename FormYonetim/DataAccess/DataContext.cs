using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FormYonetim;Trusted_Connection=True;");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Forms> Forms { get; set; }


    }
}
