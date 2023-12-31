using Komsy.Api.Common.Errors;
using Komsy.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Komsy.Api;

public static class DependencyInjection {
  public static IServiceCollection AddAPresentation(this IServiceCollection services) {

    services.AddControllers();
    services.AddSingleton<ProblemDetailsFactory, KomsyProblemDetailsFactory>();

    services.AddMappings();

    //testowo
    services.AddCors(pCorsOptions => {
      pCorsOptions.AddPolicy("DevCorsPolicy", pPolicyBuilder => {
        pPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      });
    });
    return services;
  }

}
