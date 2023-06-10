using ErrorOr;
using Komsy.Application.interfaces.Persistence;
using Komsy.Domain.Entities;
using MediatR;
using Komsy.Domain.Common.Errors;

namespace Komsy.Application.Services.Authentication.Queries;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>> {
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken) {

    await Task.CompletedTask;
    //validate the user exists
    if (_userRepository.GetByEmail(request.Email) is not User user) {
      return Errors.Authentication.InvalideCredentials;
    }

    //validate the password is correct
    if (user.Password != request.Password) {
      return new[] { Errors.Authentication.InvalideCredentials };
    }
    //Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token);
  }

}
