using OS.Application.Interfaces.Contexts;
using T.Application.Interfaces.Contexts;
using T.Application.Services.Account;
using T.Application.Services.Hotels;
using T.Application.Services.Visitor;
using T.Infrastructure.IdentityConfigs;
using T.Infrastructure.MappingProfile;
using T.Infrastructure.SetupServices;
using T.Persistence.Contexts.MongoDb;
using T.Persistence.Contexts.SqlServerDb;
using T.Website.Endpoint.Hubs;
using T.Website.Endpoint.Utilities.Filters;
using T.Website.Endpoint.Utilities.Middlewares.cs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
SqlServerSetup.Configure(builder.Services, connectionString);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ISmsService, SmsService>();

builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<IVisitorService, VisitorService>();
builder.Services.AddScoped<SaveVisitorInfoFilter>();
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();
builder.Services.AddSignalR();

//Add AutoMapper services
builder.Services.AddAutoMapper(typeof(HotelMappingProfile));

//Add DatabaseContext service
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

//Add Hotel service
builder.Services.AddTransient<IHotelService, HotelService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSetVisitorId();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<OnlineVisitorHub>("/onlinevisitorhub");

app.Run();
