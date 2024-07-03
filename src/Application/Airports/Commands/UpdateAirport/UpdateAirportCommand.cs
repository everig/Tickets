using MediatR;

namespace Application.Airports.Commands.UpdateAirport
{
    public class UpdateAirportCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }
    }
}
