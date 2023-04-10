using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WorldCitiesAPI.Data;// Here where our Db context be (ApplicationDbContext)

//program.cs will be run first
//System.Console.WriteLine("HELLO KENT");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => { 
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddDbContext<ApplicationDbContext> does not directly create an instance of the ApplicationDbContext class.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);  

var app = builder.Build();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
