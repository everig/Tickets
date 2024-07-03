using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Passengers.Commands.UpdatePassenger
{
    public class UpdatePassengerCommandHandler : IRequestHandler<UpdatePassengerCommand, int>
    {
        private readonly ITicketsContext _db;

        public UpdatePassengerCommandHandler (ITicketsContext db) => _db = db;

        public async Task<int> Handle(UpdatePassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = await _db.Passengers.FindAsync(new object[] { request.ContactData },cancellationToken);
            if (passenger == null || passenger.ContactData != request.ContactData) 
            {
                throw new NotFoundException(nameof(Passenger), request.ContactData);
            }
            passenger.ContactData = request.ContactData;
            passenger.PassengerName = request.PassengerName;
            passenger.Email = request.Email;
            await _db.SaveChangesAsync(cancellationToken);
            return passenger.ContactData;
        }
    }
}
