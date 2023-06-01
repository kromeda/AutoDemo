namespace AutoDemo.Persistance.Data;

internal static class SeedData
{
    private static readonly string[] _brands = { "BMW", "Mercedes-Benz", "УАЗ", "Caddilac" };
    private static readonly string[] _models = { "Z4", "E320", "Patriot", "SRX4", "T-34" };
    private static readonly Random _rnd = new Random();
    private static readonly double _minutesInDay = TimeSpan.FromDays(1).TotalMinutes;

    public static VendorDb[] Vendors =
    {
        new VendorDb { Id = 1, Name = "Бакра", CreatedAt = RandomTime() },
        new VendorDb { Id = 2, Name = "Рольф", CreatedAt = RandomTime() },
        new VendorDb { Id = 3, Name = "Keocera", CreatedAt = RandomTime() },
        new VendorDb { Id = 4, Name = "ИЖ", CreatedAt = RandomTime() },
        new VendorDb { Id = 5, Name = "Москвич", CreatedAt = RandomTime() }
    };

    public static OfferDb GetRandomOffer(int id)
    {
        return new OfferDb
        {
            Id = id,
            Brand = _brands[_rnd.Next(0, _brands.Length - 1)],
            Model = _models[_rnd.Next(0, _models.Length - 1)],
            SupplierId = Vendors[_rnd.Next(1, Vendors.Length - 1)].Id,
            RegisteredAt = RandomTime()
        };
    }

    private static DateTime RandomTime()
    {
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        int minutes = _rnd.Next((int)_minutesInDay);

        return start
            .AddDays(_rnd.Next(range))
            .AddMinutes(minutes);
    }
}