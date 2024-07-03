using MediatR;

namespace Application.Seats.Commands.DeleteSeat
{
    public class DeleteSeatCommand : IRequest<SeatId>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
    }
}
