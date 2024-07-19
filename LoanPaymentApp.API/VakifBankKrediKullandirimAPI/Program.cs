using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VakifBankKrediKullandirimAPI;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Helpers;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --------------------------  added later -----------------------------
// ApplicationDbContext

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteDatabase"));
});

// Repositories
builder.Services.AddScoped<IParameterRepository, ParameterRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISpecialOfferRepository, SpecialOfferRepository>();
builder.Services.AddScoped<IPaymentPlanRepository, PaymentPlanRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// -------------------------- end added later --------------------------

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}


if (args.Length == 1 && args[0].ToLower() == "resetdata")
{
    Seed.ResetData(app);
}

if (builder.Configuration.GetSection("AppSettings:ResetAndSeed").Value == "true")
{
    Seed.ResetData(app);
    Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Seed.SeedData(app);
}

app.UseHttpsRedirection();

// ------------------- added later ---------------------
// Enable Cross-Origin Resource Sharing
app.UseCors(options =>
{
    var clientUrl = app.Configuration.GetSection("AppSettings:ClientUrl").Value;
    options.WithOrigins(clientUrl).AllowAnyHeader().AllowAnyMethod();
});
// ------------------- end added later -----------------




app.UseAuthorization();

app.MapControllers();

app.Run();
