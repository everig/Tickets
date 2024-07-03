using MediatR;

namespace Application.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime BookDate { get; set; }
    }
}
