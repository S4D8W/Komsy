
using ErrorOr;
using Komsy.Application.Common.Interfaces.Persistence;
using Komsy.Domain.Common.Errors;
using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService {

  private readonly IMongoRepository<User> _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(IMongoRepository<User> userRepository,
                               IJwtTokenGenerator jwtTokenGenerator) {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public ErrorOr<AuthenticationResult> LoginAsync(string email, string password) {
    throw new NotImplementedException();
  }

  public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password) {

    //validate the user doesn't exist
    if (await _userRepository.FindOneAsync(x => x.Email == email) is not null) {
      return Errors.User.DuplicateEmail;
    }

    //create user (generate unique id) & Persist to DB
    var user = new User {
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      Password = password
    };

    await _userRepository.InsertOneAsync(user);

    //Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
    user,
    token);
  }

  
}
