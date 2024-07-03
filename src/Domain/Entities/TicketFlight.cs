namespace Domain.Entities
{
    public class TicketFlight
    {
        public Guid Id { get; set; }
        public string FlightId { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public int Amount { get; set; }

        public Flight Flight { get; set; }
        public List<BoardingPass> BoardingPasess { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
