using MediatR;

namespace Application.TicketsFlight.Commands.UpdateTicketFlight
{
    public class UpdateTicketFlightCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string FlightId { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public int Amount { get; set; }
    }
}
