
using ErrorOr;
using Komsy.Application.interfaces.Persistence;
using MediatR;
using Komsy.Domain.Common.Errors;
using Komsy.Domain.Entities;

namespace Komsy.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>> {

  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken) {

    await Task.CompletedTask;
    //validate the user doesn't exist
    if (_userRepository.GetByEmail(command.Email) is not null) {
      return Errors.User.DuplicateEmail;
    }

    //create user (generate unique id) & Persist to DB
    var user = new User {
      FirstName = command.FirstName,
      LastName = command.LastName,
      Email = command.Email,
      Password = command.Password
    };

    _userRepository.Add(user);

    //Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(
      user,
      token);
  }


}
