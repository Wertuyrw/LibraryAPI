﻿using Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryAPI.Extensions
{
    public static class AuthenticationWithJwtBearerExtension
    {
        public static AuthenticationBuilder AddAuthenticationWithJwtBearer(this IServiceCollection collection,
            JwtOptions jwtOption)
        {
            if (jwtOption is not
                {
                    Issuer: not null,
                    Audience: not null,
                    SecretKey: not null
                })
                return collection.AddAuthentication()
                    .AddJwtBearer();

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecretKey));

            return collection.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOption.Issuer,
                        ValidAudience = jwtOption.Audience,
                        IssuerSigningKey = signingKey
                    };
                });
        }
    }
}
