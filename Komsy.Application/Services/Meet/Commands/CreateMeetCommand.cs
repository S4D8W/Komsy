using ErrorOr;
using Komsy.Application.Services.Meet.Common;
using MediatR;

namespace Komsy.Application.Services.Meet.Commands;


public record CreateMeetCommand(
  string Name,
  string Description,
  DateTime Date_Start,
  DateTime Date_End,
  string User_Id,
  string MeetType
  ) : IRequest<ErrorOr<MeetResult>>;
