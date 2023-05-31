namespace AutoDemo.Persistance.Data.Mappers;

internal static class EntityToModelMapper
{
    internal static OfferDb ToModel(this Offer offer)
    {
        return new OfferDb
        {
            Id = offer.Id,
            Brand = offer.Brand,
            Model = offer.Model,
            RegisteredAt = offer.RegisteredAt,
            SupplierId = offer.Supplier?.Id ?? throw new InvalidOperationException()
        };
    }

    internal static VendorDb ToModel(this Vendor vendor)
    {
        return new VendorDb
        {
            Id = vendor.Id,
            Name = vendor.Name,
            CreatedAt = vendor.CreatedAt,
        };
    }
}
