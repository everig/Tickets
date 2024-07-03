using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.TicketsFlight.Commands.DeleteTicketFlight
{
    public class DeleteTicketFlightCommandHandler : IRequestHandler<DeleteTicketFlightCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public DeleteTicketFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(DeleteTicketFlightCommand request, CancellationToken cancellationToken)
        {
            var ticketFlight = await _db.TicketsFlight.FindAsync(new object[] { request.Id }, cancellationToken);
            if (ticketFlight == null || ticketFlight.Id != request.Id)
            {
                throw new NotFoundException(nameof(TicketFlight), request.Id);
            }
            _db.TicketsFlight.Remove(ticketFlight);
            await _db.SaveChangesAsync(cancellationToken);
            return ticketFlight.Id;
        }
    }
}
