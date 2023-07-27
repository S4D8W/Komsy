

namespace Komsy.Contracts.Meeting {

  public record CreateMeetRequest(
    string User_Id,
    string Name,
    string Description,
    DateTime Date_Start,
    DateTime Date_End,
    string State,
    string Street,
    string City,
    string MeetType,
    string Country,
    string ZipCode
  );
}
