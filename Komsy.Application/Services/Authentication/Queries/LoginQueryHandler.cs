using ErrorOr;
using Komsy.Application.interfaces.Persistence;
using Komsy.Domain.Entities;
using MediatR;
using Komsy.Domain.Common.Errors;

namespace Komsy.Application.Services.Authentication.Queries;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>> {

  private readonly IAuthenticationService _authenticationService;

  public LoginQueryHandler(IAuthenticationService authenticationService) {
    _authenticationService = authenticationService;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken) {

    return await _authenticationService.LoginAsync(request.Email, request.Password);

  }

}
