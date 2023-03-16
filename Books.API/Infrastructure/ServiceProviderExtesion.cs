using Books.BLL;
using Books.DAL;
using Microsoft.OpenApi.Models;

namespace Books.API.Extensions
{
    public static class ServiceProviderExtesion
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IBooksService, BooksService>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.EnableAnnotations();

            });
        }
    }
}
