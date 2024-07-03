using Application.Aircrafts.Commands.CreateAircraft;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Aircraft
{
    public class CreateAircraftDto : IMapWith<CreateAircraftCommand>
    {
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAircraftDto, CreateAircraftCommand>();
        }
    }
}
