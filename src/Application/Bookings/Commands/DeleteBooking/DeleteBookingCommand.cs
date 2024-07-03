using MediatR;

namespace Application.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
