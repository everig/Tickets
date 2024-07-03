using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BoardingPasses.Queries.GetBoardingPass
{
    public class GetBoardingPassQueryHandler : IRequestHandler<GetBoardingPassQuery, BoardingPassVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetBoardingPassQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BoardingPassVm> Handle(GetBoardingPassQuery request, CancellationToken cancellationToken)
        {
            var boardingPass = await _db.BoardingPasses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boardingPass == null || boardingPass.Id != request.Id)
            {
                throw new NotFoundException(nameof(BoardingPass), request.Id);
            }
            return _mapper.Map<BoardingPassVm>(boardingPass);
        }
    }
}
