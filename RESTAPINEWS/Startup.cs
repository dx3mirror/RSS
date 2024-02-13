using ClassDomain.Repository;
using ClassEntity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace RESTAPINEWS
{
    public class Startup
    {
        public void Configure(IServiceCollection services)
        {
            services.AddDbContext<NewsContext>(options =>
        options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IRSSRepository, RSS>();
            services.AddControllers();

        }
    }
}
