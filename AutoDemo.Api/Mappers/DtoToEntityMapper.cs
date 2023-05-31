namespace AutoDemo.Api.Mappers;

internal static class DtoToEntityMapper
{
    internal static Offer ToEntity(this OfferDto offer)
    {
        return new Offer
        {
            Brand = offer.Brand,
            Model = offer.Model,
            Supplier = new Vendor { Id = offer.SupplierId },
            RegisteredAt = DateTime.Now
        };
    }
}
