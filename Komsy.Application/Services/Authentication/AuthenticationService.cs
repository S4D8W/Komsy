
using ErrorOr;

namespace Komsy.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService {
  public ErrorOr<AuthenticationResult> LoginAsync(string email, string password) {
    throw new NotImplementedException();
  }

  public ErrorOr<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password) {
    throw new NotImplementedException();
  }
}
