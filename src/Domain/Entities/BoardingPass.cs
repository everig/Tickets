namespace Domain.Entities
{
    public class BoardingPass
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

        public Passenger Passenger { get; set; }
        public Booking Booking { get; set; }
        public TicketFlight TicketFlight { get; set; } 
        public Flight Flight { get; set; }
    }
}
