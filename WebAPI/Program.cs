using System.Security.Cryptography.X509Certificates;
using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
//builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Kodlama.io Devs",
        Description = "An ASP.NET Core Web API for Kodlama.io Devs",
        Contact = new OpenApiContact
        {
            Name = "Çaðdaþ Demirel",
            Url = new Uri("https://github.com/ChaTho7")
        },
    });
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.ConfigureHttpsDefaults(options =>
    {
        //certificate for localhost domain
        X509Certificate cert =
            X509Certificate2.CreateFromCertFile(
                @"C:\Users\ChaTho\source\repos\Kodlama.io.Devs\WebAPI\Certs\iisCert.cer");

        options.ServerCertificate = new X509Certificate2(cert);
    });
});

builder.WebHost.UseUrls("http://192.168.1.7:5000", "https://192.168.1.7:44371", "http://localhost:5000", "https://localhost:44371");

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseCors(corsBuilder => corsBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
