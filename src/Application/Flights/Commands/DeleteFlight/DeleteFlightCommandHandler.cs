using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;

namespace Application.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, string>
    {
        private readonly ITicketsContext _db;

        public DeleteFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<string> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _db.Flights.FindAsync(new object[] { request.Id }, cancellationToken);
            if (flight == null || flight.Id != request.Id)
            {
                throw new NotFoundException(nameof(flight), request.Id);
            }
            _db.Flights.Remove(flight);
            await _db.SaveChangesAsync(cancellationToken);
            return flight.Id;
        }
    }
}
