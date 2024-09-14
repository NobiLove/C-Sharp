using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.EFModels;
using WebApplicationTest.Middlewares;
using WebApplicationTest.Services;

//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=Qwerasdf1;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o EFModels --force

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IUsuarioRolServicio, UsuarioRolServicio>();
builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=Qwerasdf1;Trust Server Certificate=True"));

var app = builder.Build();

app.UseMiddleware<UsuarioRolMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
