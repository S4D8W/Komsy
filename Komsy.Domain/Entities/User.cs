
namespace Komsy.Domain.Entities
{

  [BsonCollection("Users")]
  public class User : Document
  {

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

  }
}

