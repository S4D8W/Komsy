using ErrorOr;
using Komsy.Application.Services.Authentication.Common;
using MediatR;

namespace Komsy.Application.Services.Authentication.Commands.Register;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ErrorOr<AuthResetPasswordResult>> {

	private readonly IAuthenticationService _authenticationService;

	public ResetPasswordHandler(IAuthenticationService authenticationService) {
		_authenticationService = authenticationService;
	}

	public async Task<ErrorOr<AuthResetPasswordResult>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken) {

		var result = await _authenticationService.ResetPassword(request.Email);

		return result;
	}
}
