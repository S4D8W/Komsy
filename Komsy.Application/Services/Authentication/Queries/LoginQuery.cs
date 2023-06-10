using ErrorOr;
using MediatR;

namespace Komsy.Application.Services.Authentication.Queries {


  public record LoginQuery(
  string Email,
  string Password) : IRequest<ErrorOr<AuthenticationResult>>;

}
