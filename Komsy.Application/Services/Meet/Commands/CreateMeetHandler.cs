using ErrorOr;
using Komsy.Application.Services.Meet.Common;
using MediatR;

namespace Komsy.Application.Services.Meet.Commands.CreateMeet {

  public class CreateMeetCommandHandler : IRequestHandler<CreateMeetCommand, ErrorOr<MeetResult>> {
    private readonly IMeetService _meetService;

    public CreateMeetCommandHandler(IMeetService meetService) {
      _meetService = meetService;
    }

    public async Task<ErrorOr<MeetResult>> Handle(CreateMeetCommand command, CancellationToken cancellationToken) {
      return await _meetService.CreateMeetAsync(
        name: command.Name,
        description: command.Description,
        location: "Utwórz typ lokacji",
        date_Start: command.Date_Start,
        date_End: command.Date_End,
        userId: command.User_Id,
        meetType: command.MeetType

      );
    }
  }
}
