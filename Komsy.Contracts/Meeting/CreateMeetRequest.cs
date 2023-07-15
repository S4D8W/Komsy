namespace Komsy.Contracts.Meeting {

  public record CreateMeetRequest(
    string Name,
    string Description,
    DateTime Date,
    string Location
  );
}
