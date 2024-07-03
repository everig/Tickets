using MediatR;

namespace Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest<string>
    {
        public string Id { get; set; }
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
