namespace AutoDemo.Persistance.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterSqliteDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);

        services.AddScoped<IVendorRepository, VendorRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();

        return services;
    }

    private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlLiteConnection");
        SqliteConnection connection = new SqliteConnection(connectionString);
        connection.Open();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(connection);
            options.EnableSensitiveDataLogging();
        });
    }
}
