<<<<<<< HEAD

namespace Komsy.Domain.Entities.Meeting;
=======
namespace Komsy.Domain.Entities.nsMeet;
>>>>>>> aba37edb718094b5a4e63aa493a89acc922c6a2e

[BsonCollection("Meets")]
public class Meet : Document {

  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public DateTime Date_Start { get; set; }
  public DateTime Date_End { get; set; }
  public string User_Id { get; set; } = null!;
  public MeetTypeEnum MeetType { get; set; }

}
