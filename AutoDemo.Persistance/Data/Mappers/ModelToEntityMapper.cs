namespace AutoDemo.Persistance.Data.Mappers;

internal static class ModelToEntityMapper
{
    internal static Offer ToEntity(this OfferDb offer)
    {
        return new Offer
        {
            Id = offer.Id,
            Brand = offer.Brand,
            Model = offer.Model,
            Supplier = offer.Supplier.ToEntity(),
            RegisteredAt = offer.RegisteredAt
        };
    }

    internal static Vendor ToEntity(this VendorDb vendor)
    {
        return new Vendor
        {
            Id = vendor.Id,
            Name = vendor.Name,
            CreatedAt = vendor.CreatedAt
        };
    }
}
