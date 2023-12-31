using ErrorOr;
using Komsy.Application.Services.Authentication;
using Komsy.Application.Services.Authentication.Commands.Register;
using Komsy.Application.Services.Authentication.Queries;
using Komsy.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Komsy.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController {

	private readonly ISender _mediator;
	private readonly IMapper _mapper;
	public AuthenticationController(ISender mediator, IMapper mapper) {
		_mediator = mediator;
		_mapper = mapper;
	}



	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request) {

		var command = _mapper.Map<RegisterCommand>(request);

		ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

		return authResult.Match(
			authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
			errors => Problem(errors)
		);

	}


	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginRequest request) {

		var query = _mapper.Map<LoginQuery>(request);

		var authResult = await _mediator.Send(query);

		if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials) {
			return Problem(
					statusCode: StatusCodes.Status401Unauthorized,
					title: authResult.FirstError.Description
			);
		}

		return authResult.Match(
					 authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
						errors => Problem(errors)
						 );



	}

	[HttpPost("ResetPassword")]
	public async Task<IActionResult> ResetPassword(ResetPasswordRequest request) {

		var command = _mapper.Map<ResetPasswordCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			_ => Ok(),
			errors => Problem(errors)
		);

	}


}
