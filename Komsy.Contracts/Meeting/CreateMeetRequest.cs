

namespace Komsy.Contracts.Meeting {

  public record CreateMeetRequest(
    string Name,
    string Description,
    DateTime Date,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode
  );
}
