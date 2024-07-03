using MediatR;

namespace Application.BoardingPasses.Commands.DeleteBoardingPass
{
    public class DeleteBoardingPassCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid TicketFlightId { get; set; }
    }
}
