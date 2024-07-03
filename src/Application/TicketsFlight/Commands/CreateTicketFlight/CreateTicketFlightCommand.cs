using MediatR;

namespace Application.TicketsFlight.Commands.CreateTicketFlight
{
    public class CreateTicketFlightCommand : IRequest<Guid>
    {
        public string FlightId { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public int Amount { get; set; }
    }
}
