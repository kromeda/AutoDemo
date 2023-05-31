namespace AutoDemo.Persistance.Data.Repositories;

public sealed class VendorRepository : IVendorRepository
{
    private readonly AppDbContext _context;

    public VendorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IList<VendorTopInfo>> GetTopVendors(CancellationToken token)
    {
        return await _context.VendorTop
            .FromSqlRaw(Scripts.GetTopVendorsScript)
            .AsNoTracking()
            .ToListAsync(token);
    }
}