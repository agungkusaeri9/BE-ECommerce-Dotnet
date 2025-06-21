using backend_dotnet.Extentions;
using backend_dotnet.Helpers;
using backend_dotnet.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
var configuration = builder.Configuration;


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}); ;

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Masukkan JWT token tanpa kata 'Bearer', misal: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",             
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });
});

//builder.Services.AddScoped<StockService>();
//builder.Services.AddScoped<ProductPromoService>();


var app = builder.Build();


//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API V1");
    });
}


app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
