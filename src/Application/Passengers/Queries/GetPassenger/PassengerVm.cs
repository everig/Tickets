using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Passengers.Queries.GetPassenger
{
    public class PassengerVm : IMapWith<Passenger>
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Passenger, PassengerVm>();
        }
    }
}
