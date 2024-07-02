using CoreBusiness.Interface;
using CoreBusiness.Service;
using DataAccess.EFRepository;
using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var str = builder.Configuration["ConnectionStrings:NorthwindConnection"];

builder.Services.AddDbContext<NorthwindContext>(options=> options.UseSqlServer(str));

builder.Services.AddScoped<IRepository<Product>,EFRepository<Product>>();
builder.Services.AddScoped<IRepository<Category>,EFRepository<Category>>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


