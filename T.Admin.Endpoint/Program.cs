using FluentValidation;
using FluentValidation.AspNetCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Hotels;
using T.Application.Interfaces.Contexts;
using T.Application.Services.Hotels;
using T.Application.Services.Visitor;
using T.Infrastructure.ImageServer;
using T.Infrastructure.MappingProfile;
using T.Infrastructure.SetupServices;
using T.Persistence.Contexts.MongoDb;
using T.Persistence.Contexts.SqlServerDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<IVisitorService, VisitorService>();
builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();
builder.Services.AddTransient<IImageUploadService, ImageUploadService>();
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
SqlServerSetup.Configure(builder.Services, connectionString);

//Add DatabaseContext
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

//FluentValidation
// builder.Services.AddTransient<IValidator<RegisterHotelDto>, RegisterHotelValidator>();
//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(HotelMappingProfile));
//Add HotelService
builder.Services.AddTransient<IHotelService, HotelService>();

//Add RoomService
builder.Services.AddTransient<IRoomService, RoomService>();

var app = builder.Build();

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
