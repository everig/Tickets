using MediatR;

namespace Application.Passengers.Commands.CreatePassenger
{
    public class CreatePassengerCommand : IRequest<int>
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }
    }
}
