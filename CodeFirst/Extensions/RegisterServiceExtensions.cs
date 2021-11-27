using CodeFirst.Data;
using CodeFirst.Data.Repositories.Orders;
using CodeFirst.Data.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.Extensions
{
    public static class RegisterServiceExtensions
    {
        public static void ServiceRegisterExtension(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
