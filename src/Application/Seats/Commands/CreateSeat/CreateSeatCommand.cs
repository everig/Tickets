using MediatR;

namespace Application.Seats.Commands.CreateSeat
{
    public class CreateSeatCommand : IRequest<SeatId>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }
    }
}
