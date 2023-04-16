using CantinaFacil.Shared.Kernel.GuardCauses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using CantinaFacil.Shared.Kernel.API.Authorization.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace CantinaFacil.Shared.Kernel.API.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration, string publicKey)
        {
            Guard.Null(services, nameof(services));
            Guard.Null(publicKey, nameof(publicKey));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                var rsa = RSA.Create();
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };

                //options.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context =>
                //    {
                //        Console.WriteLine(context.Exception.Message);
                //        return Task.CompletedTask;
                //    }
                //};
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var autorizacao = scope.ServiceProvider.GetService<IBaseAutorizacaoApi>();
            var publicKey = autorizacao.ObterChavePublicaAsync().Result.Data.ToString();
            services.AddJwtAuthentication(configuration, publicKey);
        }
    }
}
