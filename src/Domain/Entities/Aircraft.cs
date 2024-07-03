using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aircraft
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

        public List<Seat> Seats { get; set; }
        public List<Flight> Flights { get; set; }
        public List<TicketFlight> TicketsFlight { get; set; }
    }
}
