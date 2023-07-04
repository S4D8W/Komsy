namespace Komsy.Domain.Entities.nsMeet;

[BsonCollection("Meets")]
public class Meet : Document {

  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public DateTime Date_Start { get; set; }
  public DateTime Date_End { get; set; }
  public string User_Id { get; set; } = null!;
  public MeetTypeEnum MeetType { get; set; }

}
