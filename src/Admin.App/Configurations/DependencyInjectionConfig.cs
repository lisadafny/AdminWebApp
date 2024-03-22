using Admin.Business.Interfaces;
using Admin.Business.Services;
using Admin.Data.Context;
using Admin.Data.Repository;

namespace Admin.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AdminDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
