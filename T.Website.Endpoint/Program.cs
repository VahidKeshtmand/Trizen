using OS.Application.Interfaces.Contexts;
using T.Application.Images;
using T.Application.Interfaces.Contexts;
using T.Application.Services.Account;
using T.Application.Services.Baskets;
using T.Application.Services.Bookings;
using T.Application.Services.Comments;
using T.Application.Services.Discounts;
using T.Application.Services.Flights;
using T.Application.Services.Hotels;
using T.Application.Services.Orders;
using T.Application.Services.PaymentServices;
using T.Application.Services.Visitor;
using T.Infrastructure.IdentityConfigs;
using T.Infrastructure.MappingProfile;
using T.Infrastructure.SetupServices;
using T.Persistence.Contexts.MongoDb;
using T.Persistence.Contexts.SqlServerDb;
using T.Website.Endpoint.Hubs;
using T.Website.Endpoint.Services;
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
builder.Services.AddTransient<IFlightServiceUI, FlightServiceUI>();
builder.Services.AddTransient<IFlightService, FlightService>();

builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<IVisitorService, VisitorService>();
builder.Services.AddScoped<SaveVisitorInfoFilter>();
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();
builder.Services.AddTransient<ICommentServiceUI, CommentServiceUI>();
builder.Services.AddTransient<ICommentService, CommentService>();

builder.Services.AddTransient<IBasketService, BasketService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IImageService, ImageService>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.LoginPath = "/Account/Unauthorize";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddSignalR();

//Add AutoMapper services
builder.Services.AddAutoMapper(typeof(HotelMappingProfile));

//Add DatabaseContext service
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();
builder.Services.AddTransient<IIdentityDatabaseContext, IdentityDatabaseContext>();

builder.Services.AddTransient<IHotelServiceUI, HotelServiceUI>();
builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IRoomService, RoomService>();


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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "hotelDetail",
    pattern: "Hotel/{city}/{slug}/Detail",
    defaults: new { Controller = "Hotel", action = "Detail" });

app.MapControllerRoute(
    name: "roomsList",
    pattern: "Hotel/{hotelSlug}/Rooms",
    defaults: new { Controller = "Hotel", action = "RoomsList" });

app.MapControllerRoute(
    name: "roomDetails",
    pattern: "Hotel/{hotelSlug}/{roomSlug}/RoomDetails",
    defaults: new { Controller = "Hotel", action = "RoomDetails" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// app.MapHub<OnlineVisitorHub>("/onlinevisitorhub");

app.Run();
