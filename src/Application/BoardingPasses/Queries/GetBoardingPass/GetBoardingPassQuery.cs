using MediatR;

namespace Application.BoardingPasses.Queries.GetBoardingPass
{
    public class GetBoardingPassQuery : IRequest<BoardingPassVm>
    {
        public Guid Id { get; set; }
    }
}
