
using Komsy.Application.Services.Authentication;
using Komsy.Application.Services.Authentication.Commands.Register;
using Komsy.Application.Services.Authentication.Common;
using Komsy.Application.Services.Authentication.Queries;
using Komsy.Contracts.Authentication;
using Mapster;

namespace Komsy.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister {

	public void Register(TypeAdapterConfig config) {

		config.NewConfig<RegisterRequest, RegisterCommand>();

		config.NewConfig<LoginRequest, LoginQuery>();

		config.NewConfig<AuthenticationResult, AuthenticationResponse>()
			.Map(dest => dest.Token, src => src.Token)
			.Map(dest => dest, src => src.User);

		config.NewConfig<AuthResetPasswordResult, ResetPasswordResponse>();

	}

}
