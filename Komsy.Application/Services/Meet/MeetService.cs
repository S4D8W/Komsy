using ErrorOr;
using Komsy.Application.Common.Interfaces.Persistence;
using Komsy.Application.Services.Meeting.Common;
using Komsy.Domain;
using Komsy.Domain.Entities.Meeting;

namespace Komsy.Application.Services.Meeting;

public class MeetService : IMeetService {

  private readonly IMongoRepository<Komsy.Domain.Entities.Meeting.Meet> _meetRepository;

  public Task<ErrorOr<MeetResult>> CreateMeetAsync(string createUserId, string name, string description, Location location, DateTime date_Start, DateTime date_End, string userId, string meetType) {


    throw new NotImplementedException();
  }

  public async Task<ErrorOr<MeetResult>> CreateMeetAsync(string createUserId, string name, string description, Location location, DateTime date_Start, DateTime date_End, string meetType) {

    //create new meet
    Meet meet = new Meet() {
      Name = name,
      Description = description,
      Date_Start = date_Start,
      Date_End = date_End,
      User_Id = createUserId,
      MeetType = (MeetTypeEnum)Enum.Parse(typeof(MeetTypeEnum), meetType)

    };

    //save meet
    await _meetRepository.InsertOneAsync(meet);

    //return meet
    return new MeetResult(meet);



    throw new NotImplementedException();

  }
}
