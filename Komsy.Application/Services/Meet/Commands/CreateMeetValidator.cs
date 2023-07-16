using FluentValidation;

namespace Komsy.Application.Services.Meeting.Commands.CreateMeet {
  public class CreateMeetCommandValidator : AbstractValidator<CreateMeetCommand> {
    public CreateMeetCommandValidator() {
      RuleFor(v => v.Name)
        .NotEmpty().WithMessage("Name is required")
        .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
      RuleFor(v => v.Description)
        .NotEmpty().WithMessage("Description is required")
        .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
      RuleFor(v => v.Date_Start)
        .NotEmpty().WithMessage("Date_Start is required");
      RuleFor(v => v.Date_End)
        .NotEmpty().WithMessage("Date_End is required");
      RuleFor(v => v.User_Id)
        .NotEmpty().WithMessage("User_Id is required");
      RuleFor(v => v.MeetType)
        .NotEmpty().WithMessage("MeetType is required");
    }
  }
}
