using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Passengers.Queries.GetPassenger
{
    public class GetPassengerQueryHandler : IRequestHandler<GetPassengerQuery, PassengerVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetPassengerQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PassengerVm> Handle(GetPassengerQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _db.Passengers.FindAsync(new object[] { request.ContactData } ,cancellationToken);
            if (passenger == null || passenger.ContactData != request.ContactData) 
            { 
                throw new NotFoundException(nameof(Passenger), request.ContactData);
            }
            return _mapper.Map<PassengerVm>(passenger);
        }
    }
}
