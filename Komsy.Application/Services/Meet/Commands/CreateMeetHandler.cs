using ErrorOr;
using Komsy.Application.Services.Meeting;
using Komsy.Application.Services.Meeting.Common;
using MediatR;

namespace Komsy.Application.Services.Meeting.Commands.CreateMeet {

  public class CreateMeetCommandHandler : IRequestHandler<CreateMeetCommand, ErrorOr<MeetResult>> {
    private readonly IMeetService _meetService;
    public CreateMeetCommandHandler(IMeetService meetService) {
      _meetService = meetService;
    }

    public async Task<ErrorOr<MeetResult>> Handle(CreateMeetCommand command, CancellationToken cancellationToken) {
      return await _meetService.CreateMeetAsync(
        createUserId: command.UserId,
        name: command.Name,
        description: command.Description,
        location: command.Location,
        date_Start: command.Date_Start,
        date_End: command.Date_End,
        meetType: command.MeetType

      );
    }
  }
}
