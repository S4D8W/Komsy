namespace Komsy.Application.Services.Authentication.Common;


public record AuthResetPasswordResult(
	bool HasResetPassword,
	string NewPassword
);
