using Application.Aircrafts.Commands.UpdateAircraft;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Aircraft
{
    public class UpdateAircraftDto : IMapWith<UpdateAircraftCommand>
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAircraftDto, UpdateAircraftCommand>();
        }
    }
}
