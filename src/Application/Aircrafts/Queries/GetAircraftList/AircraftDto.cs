using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Aircrafts.Queries.GetAircraftList
{
    public class AircraftDto : IMapWith<Aircraft>
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Aircraft, AircraftDto>();
        }
    }
}
