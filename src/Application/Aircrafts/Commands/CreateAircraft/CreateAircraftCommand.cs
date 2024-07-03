using MediatR;

namespace Application.Aircrafts.Commands.CreateAircraft
{
    public class CreateAircraftCommand : IRequest<Guid>
    {
        public string Model { get; set; }
        public int Range { get; set; }
        public int MaxSeats { get; set; }

    }
}
