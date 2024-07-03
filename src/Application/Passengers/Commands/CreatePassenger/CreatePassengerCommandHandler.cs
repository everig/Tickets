using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Passengers.Commands.CreatePassenger
{
    public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand, int>
    {
        private readonly ITicketsContext _db;

        public CreatePassengerCommandHandler(ITicketsContext db) => _db = db;

        public async Task<int> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = new Passenger
            {
                ContactData = request.ContactData,
                PassengerName = request.PassengerName,
                Email = request.Email
            };
            await _db.Passengers.AddAsync(passenger, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return passenger.ContactData;
        }
    }
}
