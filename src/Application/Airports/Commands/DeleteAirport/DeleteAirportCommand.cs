using MediatR;

namespace Application.Airports.Commands.DeleteAirport
{
    public class DeleteAirportCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
