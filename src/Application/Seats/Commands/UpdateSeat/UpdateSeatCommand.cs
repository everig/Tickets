using MediatR;

namespace Application.Seats.Commands.UpdateSeat
{
    public class UpdateSeatCommand : IRequest<SeatId>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }
    }
}
