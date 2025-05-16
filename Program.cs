using System.Text;
using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Extentions;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using backend_dotnet.Repositories;
using backend_dotnet.Services;
using backend_dotnet.Validators.Authentication;
using backend_dotnet.Validators.Brand;
using backend_dotnet.Validators.ProductCategory;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
var configuration = builder.Configuration;
builder.Services
    .AddControllers()
    .AddFluentValidation();

builder.Services
    .AddApplicationServices()
    .AddApplicationValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDatabase(configuration)
    .AddJwtAuthentication();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = CustomValidationResponse.FormatInvalidModelResponse;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
