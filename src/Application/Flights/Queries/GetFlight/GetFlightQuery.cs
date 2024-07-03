using MediatR;

namespace Application.Flights.Queries.GetFlight
{
    public class GetFlightQuery : IRequest<FlightVm>
    {
        public string Id { get; set; }
    }
}
