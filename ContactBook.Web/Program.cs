
using ContactBook.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContactBook.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ContactBookWebContextConnection") ?? throw new InvalidOperationException("Connection string 'ContactBookWebContextConnection' not found.");

builder.Services.AddDbContext<ContactBookWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContactBookWebContext>();

// Add services to the container.
builder.Services.AddRazorPages();  
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication("Identity.Application")
    .AddCookie();
builder.Services.AddHttpClient<IContactServices, ContactServices>(Client =>
{
    Client.BaseAddress = new Uri("https://localhost:7116/");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;


app.Run();
