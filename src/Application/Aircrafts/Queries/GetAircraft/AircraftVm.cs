using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Aircrafts.Queries.GetAircraft
{
    public class AircraftVm : IMapWith<Aircraft>
    {
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Aircraft, AircraftVm>();
        }
    }
}
