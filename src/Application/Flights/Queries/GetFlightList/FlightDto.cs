using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Flights.Queries.GetFlightList
{
    public class FlightDto : IMapWith<Flight>
    {
        public string Id { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Status { get; set; }
        public string Aircraft { get; set; }
        public TimeSpan ActualDeparture { get; set; }
        public TimeSpan ActualArrival { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flight, FlightDto>()
                .ForMember(flightDto => flightDto.DepartureAirport, opt => opt.MapFrom(flight => flight.DepartureAirport.Name))
                .ForMember(flightDto => flightDto.ArrivalAirport, opt => opt.MapFrom(flight => flight.ArrivalAirport.Name))
                .ForMember(flightDto => flightDto.Aircraft, opt => opt.MapFrom(flight => flight.Aircraft.Model));
        }
    }
}
