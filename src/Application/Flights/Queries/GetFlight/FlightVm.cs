using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Flights.Queries.GetFlight
{
    public class FlightVm : IMapWith<Flight>
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
            profile.CreateMap<Flight, FlightVm>()
                .ForMember(flightVm => flightVm.DepartureAirport, opt => opt.MapFrom(flight => flight.DepartureAirport.Name))
                .ForMember(flightVm => flightVm.ArrivalAirport, opt => opt.MapFrom(flight => flight.ArrivalAirport.Name))
                .ForMember(flightVm => flightVm.Aircraft, opt => opt.MapFrom(flight => flight.Aircraft.Model));
        }
    }
}
