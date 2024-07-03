using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Airports.Commands.UpdateAirport
{
    public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public UpdateAirportCommandHandler(ITicketsContext db) => _db = db;
        public async Task<Guid> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = await _db.Airports.FindAsync(new object[] { request.Id }, cancellationToken);
            if (airport == null || airport.Id != request.Id)
            {
                throw new NotFoundException(nameof(Airport), request.Id);
            }
            airport.Name = request.Name;
            airport.City = request.City;
            airport.Coordinates = request.Coordinates;
            await _db.SaveChangesAsync(cancellationToken);
            return airport.Id;
        }
    }
}
