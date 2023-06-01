namespace AutoDemo.Persistance.Data.Mappers;

internal static class EntityToDbModelMapper
{
    internal static OfferDb ToDbModel(this Offer offer)
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

    internal static VendorDb ToDbModel(this Vendor vendor)
    {
        return new VendorDb
        {
            Id = vendor.Id,
            Name = vendor.Name,
            CreatedAt = vendor.CreatedAt,
        };
    }
}
