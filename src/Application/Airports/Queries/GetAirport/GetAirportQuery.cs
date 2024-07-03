using MediatR;

namespace Application.Airports.Queries.GetAirport
{
    public class GetAirportQuery : IRequest<AirportVm>
    {
        public Guid Id { get; set; }
    }
}
