using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public DeleteBookingCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _db.Bookings.FindAsync(new object[] { request.Id } ,cancellationToken);
            if (booking == null || booking.Id != request.Id) 
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }
            _db.Bookings.Remove(booking);
            await _db.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
    }
}
