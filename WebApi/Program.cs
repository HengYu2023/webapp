using CoreBusiness.BusinessMapping;
using CoreBusiness.Interface;
using CoreBusiness.Service;
using DataAccess.Repository;
using DataAccess.Entities;
using DataAccess.Helper;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using WebApi.PresentationMapping;

var builder = WebApplication.CreateBuilder(args);

var str = builder.Configuration["ConnectionStrings:NorthwindConnection"]??"";

builder.Services.AddDbContext<DbContext,NorthwindContext>(options=> options.UseSqlServer(str));
builder.Services.AddScoped<IDbHelper,DapperDbHelper>(provider => new DapperDbHelper(str));

builder.Services.AddAutoMapper(option =>
    {
        option.AddProfile<PresentationProfile>();
        option.AddProfile<BusinessProfile>();
    });
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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


