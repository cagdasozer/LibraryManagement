using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

public class eLibraryDbContext : DbContext
{
    public eLibraryDbContext(DbContextOptions<eLibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<OduncAlan> OduncAlanlar { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Kitap>()
            .Property(k => k.ISBN)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<OduncAlan>()
            .Property(o => o.Ad)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<OduncAlan>()
            .Property(o => o.Soyad)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<OduncAlan>()
            .Property(o => o.TCKimlikNo)
            .IsRequired()
            .HasMaxLength(11);

        modelBuilder.Entity<OduncAlan>()
            .Property(o => o.OduncAlmaTarihi)
            .IsRequired();
    }
}
