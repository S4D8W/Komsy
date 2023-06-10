
using Komsy.Application.interfaces.Persistence;
using Komsy.Domain.Entities;

namespace Komsy.Infrastructure.Persistence;

public class UserRepository : IUserRepository {

  private static readonly List<User> _users = new();

  public void Add(User user) {
    _users.Add(user);

  }

  public User? GetByEmail(string email) {

    return _users.FirstOrDefault(x => x.Email == email);

  }
}
