using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public CreateBookingCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                BookDate = request.BookDate
            };
            await _db.Bookings.AddAsync(booking, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
    }
}
