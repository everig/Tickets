using MediatR;

namespace Application.Aircrafts.Commands.DeleteAircraft
{
    public class DeleteAircraftCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } 
    }
}
