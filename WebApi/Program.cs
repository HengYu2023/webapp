using CoreBusiness.Interface;
using CoreBusiness.Service;
using DataAccess.EFRepository;
using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    private static IWebHost BuildWebHost(string[] args)
    {
        return  WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}

// var builder = WebApplication.CreateBuilder(args);
//
// var str = builder.Configuration["ConnectionStrings:NorthwindConnection"];
//
// builder.Services.AddDbContext<NorthwindContext>(options=> options.UseSqlServer(str));
//
// builder.Services.AddScoped<IRepository<Product>,EFRepository<Product>>();
// builder.Services.AddScoped<IRepository<Category>,EFRepository<Category>>();
// builder.Services.AddScoped<ICategoryService,CategoryService>();
// builder.Services.AddScoped<IProductService,ProductService>();
//
// builder.Services.AddControllers();
//
//
// var app = builder.Build();
//
// if (app.Environment.IsDevelopment())
// {
//     
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();


