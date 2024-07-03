using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Aircrafts.Commands.CreateAircraft
{
    public class CreateAircraftCommandHandler : IRequestHandler<CreateAircraftCommand, Guid>
    {
        private readonly ITicketsContext _db;
        public CreateAircraftCommandHandler(ITicketsContext db) => _db = db;
        public async Task<Guid> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
        {
            var aircraft = new Aircraft
            {
                Model = request.Model,
                Range = request.Range,
                MaxSeats = request.MaxSeats,
            };
            await _db.Aircrafts.AddAsync(aircraft, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return aircraft.Id;
        }
    }
}
