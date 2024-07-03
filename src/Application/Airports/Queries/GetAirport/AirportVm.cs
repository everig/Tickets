using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Airports.Queries.GetAirport
{
    public class AirportVm : IMapWith<Airport>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Airport, AirportVm>();
        }
    }
}
