using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public UpdateBookingCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _db.Bookings.FindAsync(new object[] { request.Id } ,cancellationToken);
            if (booking == null || booking.Id != request.Id)
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }
            booking.BookDate = request.BookDate;
            await _db.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
    }
}
