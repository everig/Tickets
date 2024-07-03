using MediatR;

namespace Application.Passengers.Commands.DeletePassenger
{
    public class DeletePassengerCommand : IRequest<int>
    {
        public int ContactData { get; set; }
    }
}
