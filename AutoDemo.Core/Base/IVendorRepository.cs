namespace AutoDemo.Core.Base;

public interface IVendorRepository
{
    public Task<IList<VendorTopInfo>> GetTopVendors(CancellationToken token);
}