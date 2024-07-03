using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Aircrafts.Commands.DeleteAircraft
{
    public class DeleteAircraftCommandHandler : IRequestHandler<DeleteAircraftCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public DeleteAircraftCommandHandler(ITicketsContext db) => _db = db;
        public async Task<Guid> Handle(DeleteAircraftCommand request, CancellationToken cancellationToken)
        {
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.Id }, cancellationToken);
            if (aircraft == null || aircraft.Id != request.Id)
            {
                throw new NotFoundException(nameof(Aircraft), request.Id);
            }
            _db.Aircrafts.Remove(aircraft);
            await _db.SaveChangesAsync(cancellationToken);
            return aircraft.Id;
        }
    }
}
