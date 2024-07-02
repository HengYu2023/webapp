using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var str = builder.Configuration["ConnectionStrings:NorthwindConnection"];

builder.Services.AddDbContext<NorthwindContext>(options=> options.UseSqlServer(str));

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


