using Microsoft.EntityFrameworkCore;
using PatentProj.Models;

using PatentProj.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;

//using NLog;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

//builder.Services.ConfigureLoggerService();
//builder.Services.ConfigureMySqlContext(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddDbContext<GIFormContext>(opt => opt.UseInMemoryDatabase("GIFormList"));
builder.Services.AddDbContext<DesignFormContext>(opt => opt.UseInMemoryDatabase("DesignFormList"));
builder.Services.AddDbContext<OwnerContext>(opt => opt.UseInMemoryDatabase("OwnerList"));

//// Add the database context to the DI container
//builder.Services.AddDbContext<GIFormContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("GIFormContext"));
//});

//// Add the Owner context to the DI container
//builder.Services.AddDbContext<OwnerContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("OwnerContext"));
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseSwagger();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

