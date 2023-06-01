WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterSqliteDependencies(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/offers", async (string brand, string model, string vendorName,
    IOfferRepository repository, CancellationToken token) =>
{
    IList<Offer> offers = await repository.GetOffers(
        new OfferFilterOptions(brand, model, vendorName), token);
    return Results.Ok(new { offers, offers.Count });
});

app.MapPost("/offers/add", async (OfferDto offer,
    IOfferRepository repository, CancellationToken token) =>
{
    await repository.CreateOffer(offer.ToEntity(), token);
    return Results.NoContent();
});

app.MapGet("/vendors/top", async (IVendorRepository repository, CancellationToken token) =>
{
    var vendors = await repository.GetTopVendors(token);
    return Results.Ok(vendors);
});

app.Run();