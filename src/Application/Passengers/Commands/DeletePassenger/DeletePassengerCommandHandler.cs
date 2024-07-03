using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Passengers.Commands.DeletePassenger
{
    public class DeletePassengerCommandHandler : IRequestHandler<DeletePassengerCommand, int>
    {
        private readonly ITicketsContext _db;

        public DeletePassengerCommandHandler(ITicketsContext db) => _db = db; 

        public async Task<int> Handle(DeletePassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = await _db.Passengers.FindAsync(new object[] { request.ContactData }, cancellationToken);
            if (passenger == null || passenger.ContactData != request.ContactData)
            {
                throw new NotFoundException(nameof(Passenger), request.ContactData);
            }
            _db.Passengers.Remove(passenger);
            await _db.SaveChangesAsync(cancellationToken);
            return passenger.ContactData;
        }
    }
}
