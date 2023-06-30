using ErrorOr;
using Komsy.Application.Common.Interfaces.Persistence;
using Komsy.Domain.Common.Errors;
using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService {

  private readonly IMongoRepository<User> _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IEncrypter _encrypter;

  public AuthenticationService(IMongoRepository<User> userRepository,
                               IJwtTokenGenerator jwtTokenGenerator,
                               IEncrypter encrypter) {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
    _encrypter = encrypter;
  }

  public async Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password) {

    //validate the user exists
    if (await _userRepository.FindOneAsync(x => x.Email == email) is not User user) {
      return Errors.Authentication.InvalideCredentials;
    }

    //validate the password is correct
    if (user.Password != password) {
      return new[] { Errors.Authentication.InvalideCredentials };
    }

    //Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token);
  }

  public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password) {

    //validate the user doesn't exist
    if (await _userRepository.FindOneAsync(x => x.Email == email) is not null) {
      return Errors.User.DuplicateEmail;
    }

    //generate salt & hash
    var salt = _encrypter.GetSalt(password);
    var hash = _encrypter.GetHash(password, salt);

    //create user (generate unique id) & Persist to DB
    var user = new User {
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      Password = hash,
      Salt = salt
    };

    await _userRepository.InsertOneAsync(user);

    //Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
    user,
    token);
  }


}
