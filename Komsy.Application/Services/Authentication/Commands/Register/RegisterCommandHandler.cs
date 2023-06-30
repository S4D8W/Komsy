
using ErrorOr;
using Komsy.Application.interfaces.Persistence;
using MediatR;
using Komsy.Domain.Common.Errors;
using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>> {

  private readonly IAuthenticationService _authenticationService;

  public RegisterCommandHandler(IAuthenticationService authenticationService) {
    _authenticationService = authenticationService;
  }


  public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken) {


    return await _authenticationService.RegisterAsync(
      command.FirstName,
      command.LastName,
      command.Email,
      command.Password
    );

  }


}
