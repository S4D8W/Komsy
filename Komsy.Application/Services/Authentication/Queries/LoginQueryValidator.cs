
using FluentValidation;

namespace Komsy.Application.Services.Authentication.Queries {
  public class LoginQueryValidator : AbstractValidator<LoginQuery> {

    public LoginQueryValidator() {

      RuleFor(x => x.Email).NotEmpty().EmailAddress();
      RuleFor(x => x.Password).NotEmpty();

    }
  }
}
