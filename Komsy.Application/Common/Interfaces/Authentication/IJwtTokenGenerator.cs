using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication;

public interface IJwtTokenGenerator {
  string GenerateToken(User user);
}
