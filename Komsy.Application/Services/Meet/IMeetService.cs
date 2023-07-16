using ErrorOr;
using Komsy.Application.Services.Meeting.Common;
using Komsy.Domain;

namespace Komsy.Application.Services.Meeting;

public interface IMeetService {

  Task<ErrorOr<MeetResult>> CreateMeetAsync(string createUserId, string name, string description, Location location,
                                            DateTime date_Start, DateTime date_End, string meetType);
}
