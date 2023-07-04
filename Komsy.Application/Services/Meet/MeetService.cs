using ErrorOr;
using Komsy.Application.Services.Meet.Common;

namespace Komsy.Application.Services.Meet;

public class MeetService : IMeetService {

  public Task<ErrorOr<MeetResult>> CreateMeetAsync(string name, string description, string location, DateTime date_Start, DateTime DateEnd, string userId) {
    throw new NotImplementedException();
  }

}
