using ErrorOr;
using Komsy.Application.Services.Meet.Common;


namespace Komsy.Application.Services.Meet;

public interface IMeetService {

  Task<ErrorOr<MeetResult>> CreateMeetAsync(string name, string description, string location, DateTime date_Start, DateTime date_End, string userId, string meetType);
}
