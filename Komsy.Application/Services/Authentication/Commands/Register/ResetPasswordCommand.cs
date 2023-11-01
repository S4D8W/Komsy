using ErrorOr;
using Komsy.Application.Services.Authentication.Common;
using MediatR;

namespace Komsy.Application.Services.Authentication.Commands.Register;


public record ResetPasswordCommand(
  string Email
) : IRequest<ErrorOr<AuthResetPasswordResult>>;
