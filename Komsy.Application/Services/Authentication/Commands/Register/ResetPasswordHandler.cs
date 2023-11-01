using ErrorOr;
using Komsy.Application.Services.Authentication.Common;
using Komsy.Application.Services.Email;
using MediatR;

namespace Komsy.Application.Services.Authentication.Commands.Register;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ErrorOr<AuthResetPasswordResult>> {

	private readonly IAuthenticationService _authenticationService;
	private readonly IEmailService _emailService;

	public ResetPasswordHandler(IAuthenticationService authenticationService, IEmailService emailService) {
		_authenticationService = authenticationService;
		_emailService = emailService;
	}

	public async Task<ErrorOr<AuthResetPasswordResult>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken) {

		var result = await _authenticationService.ResetPassword(request.Email);

		if (result.IsError) {
			return result;
		}

		await _emailService.SendResetPasswordAsync(
			email: request.Email,
			password: result.Value.NewPassword
		);

		return result;
	}
}
