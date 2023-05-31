namespace AutoDemo.Persistance.Data.Repositories;

public sealed class OfferRepository : IOfferRepository
{
    private readonly AppDbContext _context;

    public OfferRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateOffer(Offer offer, CancellationToken token)
    {
        await _context.Offers.AddAsync(offer.ToModel(), token);
        await _context.SaveChangesAsync(token);
    }

    public async Task<IList<Offer>> GetOffers(OfferFilterOptions filter, CancellationToken token)
    {
        List<OfferDb> models = await _context.Offers
            .Where(offer => string.IsNullOrEmpty(filter.Brand) || offer.Brand == filter.Brand)
            .Where(offer => string.IsNullOrEmpty(filter.Model) || offer.Model == filter.Model)
            .Where(offer => string.IsNullOrEmpty(filter.VendorName) || offer.Supplier.Name == filter.VendorName)
            .Include(offer => offer.Supplier)
            .AsNoTracking()
            .ToListAsync(token);

        return models.Select(x => x.ToEntity()).ToList();
    }
}