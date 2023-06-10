using ErrorOr;
using MediatR;

namespace Komsy.Application.Services.Authentication.Commands.Register;

public record RegisterCommand(
  string FirstName,
  string LastName,
  string Email,
  string Password) : IRequest<ErrorOr<AuthenticationResult>>;
