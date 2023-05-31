namespace AutoDemo.Persistance.Data;

internal static class SeedData
{
    private static readonly string[] _brands = { "BMW", "Mercedes-Benz", "УАЗ", "Caddilac" };
    private static readonly string[] _models = { "Z4", "E320", "Patriot", "SRX4", "T-34" };
    private static readonly Random _rnd = new Random();

    public static VendorDb[] Vendors =
    {
        new VendorDb { Id = 1, Name = "Бакра", CreatedAt = DateTime.Parse("01.12.2005") },
        new VendorDb { Id = 2, Name = "Рольф", CreatedAt = DateTime.Parse("12.10.2013") },
        new VendorDb { Id = 3, Name = "Keocera", CreatedAt = DateTime.Parse("31.12.2020") },
        new VendorDb { Id = 4, Name = "ИЖ", CreatedAt = DateTime.Parse("07.05.2004") },
        new VendorDb { Id = 5, Name = "Москвич", CreatedAt = DateTime.Parse("10.11.2005") }
    };

    public static OfferDb GetRandomOffer(int id)
    {
        return new OfferDb
        {
            Id = id,
            Brand = _brands[_rnd.Next(0, _brands.Length - 1)],
            Model = _models[_rnd.Next(0, _models.Length - 1)],
            SupplierId = Vendors[_rnd.Next(1, Vendors.Length - 1)].Id,
            RegisteredAt = RandomDay()
        };
    }

    private static DateTime RandomDay()
    {
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;

        return start.AddDays(_rnd.Next(range));
    }
}
