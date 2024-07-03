using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Domain.Entities;

namespace Application.Aircrafts.Commands.UpdateAircraft
{
    public class UpdateAircraftCommandHandler : IRequestHandler<UpdateAircraftCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public UpdateAircraftCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(UpdateAircraftCommand request, CancellationToken cancellationToken)
        {
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.Id }, cancellationToken);
            if (aircraft == null || aircraft.Id != request.Id)
            {
                throw new NotFoundException(nameof(Aircraft), request.Id);
            }
            aircraft.Model = request.Model;
            aircraft.Range = request.Range;
            aircraft.MaxSeats = request.MaxSeats;
            await _db.SaveChangesAsync(cancellationToken);
            return aircraft.Id;
        }
    }
}
