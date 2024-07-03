using MediatR;

namespace Application.Passengers.Queries.GetPassenger
{
    public class GetPassengerQuery : IRequest<PassengerVm>
    {
        public int ContactData { get; set; }
    }
}
