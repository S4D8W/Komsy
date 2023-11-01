using ErrorOr;
using Komsy.Application.Services.Authentication.Common;

namespace Komsy.Application.Services.Authentication {
  public interface IAuthenticationService {
    Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password);
    Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password);
    Task<ErrorOr<AuthResetPasswordResult>> ResetPassword(string email);
  }

}
