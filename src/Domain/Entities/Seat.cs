namespace Domain.Entities
{
    public class Seat
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }

        public Aircraft Aircraft { get; set; }
    }
}
