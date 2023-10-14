using System.Text.Json.Serialization;
using Komsy.Api.Common.Errors;
using Komsy.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Komsy.Api;

public static class DependencyInjection {
	public static IServiceCollection AddAPresentation(this IServiceCollection services) {

		services.AddControllers()
		.AddJsonOptions(pOption => {
			pOption.JsonSerializerOptions.PropertyNamingPolicy = null;
			pOption.JsonSerializerOptions.WriteIndented = true;
			pOption.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

		});

		services.AddSingleton<ProblemDetailsFactory, KomsyProblemDetailsFactory>();

		services.AddMappings();


		services.AddCors(pCorsOptions => {
			pCorsOptions.AddPolicy("DevCorsPolicy", pPolicyBuilder => {
				pPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});
		});

		return services;

	}

}
