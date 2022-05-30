using  Domain.Users;
using  Persistences.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace  Infrastructure.IdentityConfigs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionIPSBase = configuration["ConnectionString:OrclConn"];
            services.AddDbContext<IdentityDataBaseContext>(option => option.UseOracle(connectionIPSBase));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IdentityDataBaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<Role>()
                .AddErrorDescriber<CustomIdentityError>();

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                });


            services.AddScoped<IClaimsTransformation, ClaimsCustomization>();

            return services;
        }
    }
}
