namespace Komsy.Application.Services.Meeting;

public interface IMeetService {

  Task<ErrorOr<MeetResult>> CreateMeetAsync(string name, string description, string location, DateTime date_Start, DateTime date_End, string userId, string meetType);
}
