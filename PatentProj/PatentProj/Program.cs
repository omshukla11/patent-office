using Microsoft.EntityFrameworkCore;
using PatentProj.Models;

using PatentProj.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
//using NLog;

var builder = WebApplication.CreateBuilder(args);

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

