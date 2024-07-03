using MediatR;

namespace Application.Aircrafts.Queries.GetAircraft
{
    public class GetAircraftQuery : IRequest<AircraftVm>
    {
        public Guid Id { get; set; }
    }
}
