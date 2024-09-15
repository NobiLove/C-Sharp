using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

//dotnet ef dbcontext scaffold "Name=ConnectionStrings:BikestoresDB" Microsoft.EntityFrameworkCore.SqlServer -o Models --force

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BikestoresDBContext>(options => options.UseSqlServer("Name=ConnectionStrings:BikestoresDB"));//Added
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
