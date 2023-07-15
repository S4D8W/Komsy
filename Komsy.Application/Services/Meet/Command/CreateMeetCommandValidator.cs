using FluentValidation;
using Komsy.Application.Services.Meeting.Commands;

namespace Komsy.Application.Services.Meet.Command;

public class CreateMeetCommandValidator : AbstractValidator<CreateMeetCommand> {
  public CreateMeetCommandValidator() {
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Description).NotEmpty();
    RuleFor(x => x.Date).NotEmpty();
    RuleFor(x => x.Location).NotEmpty();
  }
}
