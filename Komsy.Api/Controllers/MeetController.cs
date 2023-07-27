
using Komsy.Application.Services.Meeting.Commands;
using Komsy.Contracts.Meeting;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Komsy.Api.Controllers;

[Route("Meet")]
public class MeetController : ApiController {

  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public MeetController(IMediator mediator, IMapper mapper) {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("CreateMeet")]
  public async Task<IActionResult> CreateMeet(CreateMeetRequest request) {

    var pTest = DateTime.Now.ToString();
    var command = _mapper.Map<CreateMeetCommand>(request);

    var meetResult = await _mediator.Send(command);

    return meetResult.Match(
      meetResult => Ok(_mapper.Map<MeetResponse>(meetResult)),
      errors => Problem(errors)
    );

  }
}
