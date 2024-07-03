using Application.Airports.Commands.UpdateAirport;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Airport
{
    public class UpdateAirportDto : IMapWith<UpdateAirportCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAirportDto, UpdateAirportCommand>();
        }
    }
}
