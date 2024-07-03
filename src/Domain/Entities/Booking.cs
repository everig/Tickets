namespace Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime BookDate { get; set; }
        public BoardingPass BoardingPass { get; set; }
    }
}
