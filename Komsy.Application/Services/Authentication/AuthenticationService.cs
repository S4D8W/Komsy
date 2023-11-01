using ErrorOr;
using Komsy.Application.Common.Interfaces.Persistence;
using Komsy.Application.Services.Authentication.Common;
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
			return Errors.Authentication.InvalidCredentials;
		}

		//validate the password is correct

		string hash = _encrypter.GetHash(password, user.Salt);

		if (user.Password != hash) {
			return new[] { Errors.Authentication.InvalidCredentials };
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

		user.Password = string.Empty;
		user.Salt = string.Empty;

		return new AuthenticationResult(
		user,
		token);
	}

	public async Task<ErrorOr<AuthResetPasswordResult>> ResetPassword(string email) {

		User user = await _userRepository.FindOneAsync(x => x.Email == email);

		if (user is null) {
			return Errors.Authentication.InvalidCredentials;
		}

		//generate password 8 characters long
		string newPassword = GeneratePassword();

		//generate salt & hash
		var salt = _encrypter.GetSalt(newPassword);
		var hash = _encrypter.GetHash(newPassword, salt);

		//update user password
		user.Password = hash;
		user.Salt = salt;

		await _userRepository.ReplaceOneAsync(user);

		return new AuthResetPasswordResult(
			HasResetPassword: true,
			NewPassword: newPassword
		);

	}

	private string GeneratePassword() {
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		var random = new Random();
		return new string(Enumerable.Repeat(chars, 8)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}
}
