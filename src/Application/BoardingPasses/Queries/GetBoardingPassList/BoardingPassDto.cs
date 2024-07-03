using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.BoardingPasses.Queries.GetBoardingPassList
{
    public class BoardingPassDto : IMapWith<BoardingPass>
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public string BoardingNo { get; set; }
        public string SeatNo { get; set; }
        public string FareConditious { get; set; }
        public int PassengerContactData { get; set; }
        public string PassengerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BoardingPass, BoardingPassDto>();
        }
    }
}
