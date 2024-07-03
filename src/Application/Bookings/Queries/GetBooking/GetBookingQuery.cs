using MediatR;

namespace Application.Bookings.Queries.GetBooking
{
    public class GetBookingQuery : IRequest<BookingVm>
    {
        public Guid Id { get; set; }
    }
}
