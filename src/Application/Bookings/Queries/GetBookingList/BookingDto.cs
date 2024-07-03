using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Bookings.Queries.GetBookingList
{
    public class BookingDto : IMapWith<Booking>
    {
        public Guid Id { get; set; }
        public DateTime BookDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, BookingDto>();
        }
    }
}
