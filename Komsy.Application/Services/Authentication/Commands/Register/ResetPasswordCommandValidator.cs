using FluentValidation;

namespace Komsy.Application.Services.Authentication.Commands.Register {
  public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand> {
    public ResetPasswordCommandValidator() {
      RuleFor(x => x.Email)
        .NotEmpty()
        .EmailAddress();
    }
  }
}
