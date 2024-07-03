using Application.Airports.Commands.CreateAirport;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Airport
{
    public class CreateAirportDto : IMapWith<CreateAirportCommand>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAirportDto, CreateAirportCommand>();
        }
    }
}
