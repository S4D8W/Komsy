using ErrorOr;
using Komsy.Application.Services.Meeting.Common;
using Komsy.Domain;
using MediatR;

namespace Komsy.Application.Services.Meeting.Commands;


public record CreateMeetCommand(
  string Name,
  string Description,
  DateTime Date_Start,
  DateTime Date_End,
  Location Location,
  string User_Id,
  string MeetType
  ) : IRequest<ErrorOr<MeetResult>>;
