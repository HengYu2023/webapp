using CoreBusiness.Interface;
using CoreBusiness.Service;
using DataAccess.EFRepository;
using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
        var str = new ConfigurationBuilder()
                .AddUserSecrets<Startup>()
                .Build()["ConnectionStrings:NorthwindConnection"];

        services.AddDbContext<NorthwindContext>(options=> options.UseSqlServer(str));

        services.AddScoped<IRepository<Product>,EFRepository<Product>>();
        services.AddScoped<IRepository<Category>,EFRepository<Category>>();
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<IProductService,ProductService>();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
    
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseAuthorization();

        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
        });
    }
    
}