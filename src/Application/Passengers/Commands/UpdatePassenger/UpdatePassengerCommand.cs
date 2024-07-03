using MediatR;

namespace Application.Passengers.Commands.UpdatePassenger
{
    public class UpdatePassengerCommand : IRequest<int>
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }
    }
}
