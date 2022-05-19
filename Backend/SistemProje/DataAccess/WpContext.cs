using Microsoft.EntityFrameworkCore;
using SistemProje.Entities.Concrete;

namespace SistemProje.DataAccess
{
    public class WpContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TB9KB5F;Database=Wp;Trusted_Connection=true");
        }

        public DbSet<Kullanici> tbl_Kullanici { get; set; }
        public DbSet<Mesaj> tbl_Mesaj { get; set; }
        public DbSet<SonKonusulan> tbl_SonKonusulan { get; set; }
        // public DbSet<Mesaj> tbl_Mesaj { get; set; }
        // public DbSet<Konusulan> tbl_Konusulan { get; set; }
    }
}
