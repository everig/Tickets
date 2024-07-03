using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }

        public List<Flight> ArrivalFlights { get; set; }
        public List<Flight> DepartureFlights { get; set; }
    }
}
