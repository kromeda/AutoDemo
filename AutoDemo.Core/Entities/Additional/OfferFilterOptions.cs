namespace AutoDemo.Core.Entities.Additional;

public sealed class OfferFilterOptions
{
    public OfferFilterOptions(string brand, string model, string vendorName)
    {
        Brand = brand;
        Model = model;
        VendorName = vendorName;
    }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string VendorName { get; set; }
}
