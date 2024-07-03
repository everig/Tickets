using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Bookings.Queries.GetBooking
{
    public class BookingVm : IMapWith<Booking>
    {
        public DateTime BookDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingVm>();
        }
    }
}
