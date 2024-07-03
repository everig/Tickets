using MediatR;

namespace Application.Seats.Queries.GetSeat
{
    public class GetSeatQuery : IRequest<SeatVm>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
    }
}
