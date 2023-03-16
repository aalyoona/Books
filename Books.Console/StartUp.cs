using Books.BLL;
using Books.BLL.Configs;
using Books.Cnsl.Configs;
using Books.Cnsl.Services;
using Books.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Books.Cnsl
{
    public class StartUp
    {
        private readonly IServiceProvider _serviceProvider;

        public StartUp()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyLocal"].ConnectionString;

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IBooksService, BooksService>()
                .AddSingleton<IBooksRepository, BooksRepository>()
                .AddTransient<IConsoleExecutor, ConsoleExecutor>()
                .AddDbContext<BooksContext>(options => options.UseSqlServer(conString))
                .AddAutoMapper(typeof(BuisnessMapperForCnsl).Assembly, typeof(DataMapper).Assembly)
                .BuildServiceProvider();
        }

        public void Start()
        {
            _serviceProvider.GetService<IConsoleExecutor>().Run();
        }
    }
}