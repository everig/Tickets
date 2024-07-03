using MediatR;

namespace Application.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
