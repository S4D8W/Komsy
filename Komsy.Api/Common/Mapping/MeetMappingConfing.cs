
using Komsy.Application.Services.Meeting.Commands;
using Komsy.Contracts.Meeting;
using Komsy.Domain;
using Mapster;

namespace Komsy.Api.Common.Mapping;

public class MeetMappingConfing : IRegister {

  public void Register(TypeAdapterConfig config) {

    config.NewConfig<CreateMeetRequest, CreateMeetCommand>()
      .Map(dest => dest.Location, src => this.MapLocation(src))
      .Map(dest => dest.User_Id, src => src.User_Id)
      .Map(dest => dest.Date_Start, src => src.Date_Start)
      .Map(dest => dest.Date_End, src => src.Date_End);

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

};



