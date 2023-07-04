using Komsy.Api.Controllers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Komsy.Application.Services.Meet.Common;

[Route("Meet")]
public class AuthenticationController : ApiController {

  ISender _Sender;
  IMapper _Mapper;

  public AuthenticationController(ISender sender, IMapper mapper) {
    _Sender = sender;
    _Mapper = mapper;

  }

  [HttpPost("CreateMeet")]
  public async Task<IActionResult> CreateMeet(CreateMeetRequest request) {

    var command = _Mapper.Map<CreateMeetCommand>(request);

    ErrorOr<MeetResult> meetResult = await _Sender.Send(command);

    return meetResult.Match(
      meetResult => Ok(_Mapper.Map<MeetResult>(meetResult)),
      errors => Problem(errors)
    );

  }

}
