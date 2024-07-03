namespace Domain.Entities
{
    public class Passenger
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }

        public List<BoardingPass> BoardingPasess { get; set; }
    }
}
