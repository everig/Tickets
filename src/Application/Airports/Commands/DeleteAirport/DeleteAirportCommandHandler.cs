using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Airports.Commands.DeleteAirport
{
    public class DeleteAirportCommandHandler : IRequestHandler<DeleteAirportCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public DeleteAirportCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = await _db.Airports.FindAsync(new object[] { request.Id }, cancellationToken);
            if (airport == null || airport.Id != request.Id)
            {
                throw new NotFoundException(nameof(Airport), request.Id);
            }
            _db.Airports.Remove(airport);
            await _db.SaveChangesAsync(cancellationToken);
            return airport.Id;
        }
    }
}
