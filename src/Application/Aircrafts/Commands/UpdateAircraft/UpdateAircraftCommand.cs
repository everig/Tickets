using MediatR;

namespace Application.Aircrafts.Commands.UpdateAircraft
{
    public class UpdateAircraftCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }
    }
}
