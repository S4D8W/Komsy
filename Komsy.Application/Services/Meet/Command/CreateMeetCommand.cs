using ErrorOr;
using Komsy.Application.Services.Meeting.Common;
using MediatR;

namespace Komsy.Application.Services.Meeting.Commands {

  public record CreateMeetCommand(
  string Name,
  string Description,
  DateTime Date,
  string Location,
  string? ImageUrl,
  string? VideoUrl) : IRequest<ErrorOr<MeetResult>>;

}
