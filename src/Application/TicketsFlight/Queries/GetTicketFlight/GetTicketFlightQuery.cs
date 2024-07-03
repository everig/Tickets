using MediatR;

namespace Application.TicketsFlight.Queries.GetTicketFlight
{
    public class GetTicketFlightQuery : IRequest<TicketFlightVm>
    {
        public Guid Id { get; set; }
    }
}
