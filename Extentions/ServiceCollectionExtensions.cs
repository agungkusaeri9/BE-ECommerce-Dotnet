using System.Text;
using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Interfaces.Services;
using backend_dotnet.Repositories;
using backend_dotnet.Services;
using backend_dotnet.Validators.Authentication;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend_dotnet.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
                    };

                    // Tambahkan custom handler untuk 401 Unauthorized
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse(); // prevent default 401 behavior

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var result = System.Text.Json.JsonSerializer.Serialize(new
                            {
                                success = false,
                                message = "Unauthorized. Please login to access this resource."
                            });

                            return context.Response.WriteAsync(result);
                        },

                        // Optional: Tambahan untuk 403 Forbidden
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";

                            var result = System.Text.Json.JsonSerializer.Serialize(new
                            {
                                success = false,
                                message = "You do not have permission to access this resource."
                            });

                            return context.Response.WriteAsync(result);
                        }
                    };
                });

            return services;
        }


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFileUploadService, FileUploadService>();

            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<StockService>();
            services.AddScoped<IProductPromoRepository, ProductPromoRepository>();
            services.AddScoped<IProductPromoService, ProductPromoService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(typeof(RegisterValidator).Assembly);
            });

            return services;
        }


    }

}