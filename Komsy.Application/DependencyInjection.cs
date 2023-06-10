using System.Reflection;
using FluentValidation;
using Komsy.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Komsy.Application;

public static class DependencyInjection {
  public static IServiceCollection AddApplication(this IServiceCollection services) {

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>),
                      typeof(ValidationBehavior<,>));

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    return services;

  }

}