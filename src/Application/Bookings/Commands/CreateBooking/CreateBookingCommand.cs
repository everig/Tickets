
using MediatR;

namespace Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<Guid>
    {
        public DateTime BookDate { get; set; }
    }
}
