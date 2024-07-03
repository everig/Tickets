using MediatR;

namespace Application.TicketsFlight.Commands.DeleteTicketFlight
{
    public class DeleteTicketFlightCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
