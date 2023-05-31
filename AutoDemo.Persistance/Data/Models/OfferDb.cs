namespace AutoDemo.Persistance.Data.Models;

public sealed class OfferDb
{
    public int Id { get; init; }

    public string Brand { get; init; }

    public string Model { get; init; }

    public int SupplierId { get; init; }

    public VendorDb Supplier { get; init; }

    public DateTime RegisteredAt { get; init; }
}
