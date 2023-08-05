
using Komsy.Application.Services.Meeting.Commands;
using Komsy.Contracts.Meeting;
using Komsy.Domain;
using Mapster;

namespace Komsy.Api.Common.Mapping;

public class MeetMappingConfing : IRegister {

  public void Register(TypeAdapterConfig config) {

    config.NewConfig<CreateMeetRequest, CreateMeetCommand>()
      .Map(dest => dest.Location, src => this.MapLocation(src));

  }


  private Location MapLocation(CreateMeetRequest src) {

    if (src == null) {
      return null!;
    }
    return new Location() {
      Street = src.Street,
      City = src.City,
      State = src.State,
      Country = src.Country,
      ZipCode = src.ZipCode
    };

  }

}


