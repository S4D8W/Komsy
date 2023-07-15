<<<<<<< HEAD
namespace Komsy.Application.Services.Meeting;
=======
using ErrorOr;
using Komsy.Application.Services.Meet.Common;

namespace Komsy.Application.Services.Meet;
>>>>>>> aba37edb718094b5a4e63aa493a89acc922c6a2e

public class MeetService : IMeetService {

  public Task<ErrorOr<MeetResult>> CreateMeetAsync(string name, string description, string location, DateTime date_Start, DateTime DateEnd, string userId) {
    throw new NotImplementedException();
  }

}
