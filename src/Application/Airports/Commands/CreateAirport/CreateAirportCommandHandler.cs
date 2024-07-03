using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public CreateAirportCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = new Airport
            {
                Name = request.Name,
                City = request.City,
                Coordinates = request.Coordinates,
            };
            await _db.Airports.AddAsync(airport, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return airport.Id;
        }
    }
}
