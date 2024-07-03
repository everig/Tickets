namespace Domain.Entities
{
    public class Flight
    {
        public string Id { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public string Status { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ActualDeparture { get; set; }
        public TimeSpan ActualArrival { get; set; }

        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<TicketFlight> TicketsFlight { get; set; }

    }
}
