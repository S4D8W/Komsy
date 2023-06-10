using Komsy.Domain.Entities;

namespace Komsy.Application.interfaces.Persistence;

public interface IUserRepository {
  User? GetByEmail(string email);
  void Add(User user);
}
