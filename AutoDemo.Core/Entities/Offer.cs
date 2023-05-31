namespace AutoDemo.Core.Entities;

public sealed class Offer
{
    public int Id { get; init; }

    public string Brand { get; init; }

    public string Model { get; init; }

    public Vendor Supplier { get; init; }

    public DateTime RegisteredAt { get; init; }
}