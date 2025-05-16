using System.Text;
using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using backend_dotnet.Repositories;
using backend_dotnet.Services;
using backend_dotnet.Validators.Authentication;
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

// Tambahkan service FluentValidation
// builder.Services.AddControllers()
//     .AddFluentValidation(config =>
//     {
//         config.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
//         config.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
//         config.RegisterValidatorsFromAssemblyContaining<ProductCategoryCreateValidator>();
//     });

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<ProductCategoryCreateValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<ProductCategoryUpdateValidator>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();


var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
var defaultConnection = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection)));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = CustomValidationResponse.FormatInvalidModelResponse;
});

var app = builder.Build();

// Pipeline urutan WAJIB
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // <-- penting
app.UseAuthentication(); // <-- jangan lupa
app.UseAuthorization();

app.MapControllers(); // letakkan SETELAH auth

app.Run();
