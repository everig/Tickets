using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BoardingPasses.Queries.GetBoardingPassList
{
    public class GetBoardingPassListQueryHandler : IRequestHandler<GetBoardingPassListQuery, BoardingPassListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetBoardingPassListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BoardingPassListVm> Handle(GetBoardingPassListQuery request, CancellationToken cancellationToken)
        {
            var boardingPassQuery = await _db.BoardingPasses
                .ProjectTo<BoardingPassDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new BoardingPassListVm { BoardingPasses = boardingPassQuery };
        }
    }
}
