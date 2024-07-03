using Application.Common.Mappings;
using Application.Flights.Commands.CreateFlight;
using AutoMapper;

namespace Presentation.Models.Flight
{
    public class CreateFlightDto : IMapWith<CreateFlightCommand>
    {
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public string Status { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ActualDeparture { get; set; }
        public TimeSpan ActualArrival { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFlightDto, CreateFlightCommand>();
        }
    }
}
