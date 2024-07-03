using MediatR;

namespace Application.BoardingPasses.Commands.UpdateBoardingPass
{
    public class UpdateBoardingPassCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public string FlightId { get; set; }
        public Guid TicketFlightId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public string BoardingNo { get; set; }
        public string SeatNo { get; set; }
        public string FareConditious { get; set; }
        public int PassengerContactData { get; set; }
        public string PassengerName { get; set; }
    }
}
