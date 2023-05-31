namespace AutoDemo.Persistance.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<OfferDb> Offers { get; set; }

    public DbSet<VendorDb> Suppliers { get; set; }

    public DbSet<VendorTopInfo> VendorTop { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<VendorDb>().HasData(SeedData.Vendors);
        builder.Entity<OfferDb>().HasData(Enumerable.Range(1, 15).Select(SeedData.GetRandomOffer));

        builder.Entity<OfferDb>()
            .HasOne(x => x.Supplier)
            .WithMany()
            .HasForeignKey(x => x.SupplierId);

        builder.Entity<VendorTopInfo>().HasNoKey();
    }
}