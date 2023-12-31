﻿
using MealPlanner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Komsy.Application.Common.Interfaces.Services;
using Komsy.Application.interfaces.Persistence;
using Komsy.Infrastructure.Persistence;
using Komsy.Infrastructure.Authentication;
using Komsy.Application.Services.Authentication;
using Komsy.Application.Common.Interfaces.Persistence;
using Komsy.Application.Services;
using Komsy.Infrastructure.Services;

namespace Komsy.Infrastructure;

public static class DependencyInjection {
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration) {

    services.AddAuth(configuration);
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    services.AddMongoDb(configuration);
    services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

    services.AddScoped<IUserRepository, UserRepository>();

    return services;

  }


  public static IServiceCollection AddAuth(
      this IServiceCollection services,
      ConfigurationManager configuration) {

    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.SectionName, jwtSettings);

    services.AddSingleton(Options.Create(jwtSettings));

    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddScoped<IEncrypter, Encrypter>();

    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Audience,
          IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
              jwtSettings.Secret))
        };
      });

    return services;
  }

  public static IServiceCollection AddMongoDb(
       this IServiceCollection services,
          ConfigurationManager configuration) {

    var mongoDbSettings = new MongoDbSettings();
    configuration.Bind(MongoDbSettings.SectionName, mongoDbSettings);

    services.AddSingleton(Options.Create(mongoDbSettings));

    services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SectionName));
    services.AddSingleton<MongoDbSettings>(mongoDbSettings);

    return services;
  }

}
