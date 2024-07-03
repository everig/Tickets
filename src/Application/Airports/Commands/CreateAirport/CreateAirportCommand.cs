using MediatR;

namespace Application.Airports.Commands.CreateAirport
{
    public class CreateAirportCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Coordinates { get; set; }
    }
}
