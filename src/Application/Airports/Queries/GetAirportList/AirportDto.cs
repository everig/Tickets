using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Airports.Queries.GetAirportList
{
    public class AirportDto : IMapWith<Airport>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Airport, AirportDto>();
        }
    }
}
