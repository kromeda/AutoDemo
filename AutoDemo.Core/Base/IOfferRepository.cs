namespace AutoDemo.Core.Base;

public interface IOfferRepository
{
    Task CreateOffer(Offer offer, CancellationToken token);

    Task<IList<Offer>> GetOffers(OfferFilterOptions filter, CancellationToken token);
}
