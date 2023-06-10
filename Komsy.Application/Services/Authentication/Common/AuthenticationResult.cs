using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication;

public record AuthenticationResult(
 User User,
 string Token
);

