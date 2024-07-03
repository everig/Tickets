using MediatR;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommand : IRequest<string>
    {
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public string Status { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ActualDeparture { get; set; }
        public TimeSpan ActualArrival { get; set; }
    }
}
