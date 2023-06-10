using ErrorOr;

namespace Komsy.Application.Services.Authentication {
  public interface IAuthenticationService {
    ErrorOr<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> LoginAsync(string email, string password);
  }
}
