using Application.Interfaces;
using Domain;
using Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TicketsContext : DbContext, ITicketsContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<BoardingPass> BoardingPasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TicketFlight> TicketsFlight { get; set; }

        public TicketsContext(DbContextOptions<TicketsContext> options) : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TicketFlightConfiguration());
            builder.ApplyConfiguration(new AircraftConfiguration());
            builder.ApplyConfiguration(new PassengerConfiguration());
            builder.ApplyConfiguration(new AirportConfiguration());
            builder.ApplyConfiguration(new BoardingPassConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new FlightConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

//namespace Infrastructure.Context
//{
//    public class TicketsContext : DbContext, ITicketsContext
//    {
//        public DbSet<Aircraft> Aircrafts { get; set; }
//        public DbSet<Airport> Airports { get; set; }
//        public DbSet<BoardingPass> BoardingPasses { get; set; }
//        public DbSet<Booking> Bookings { get; set; }
//        public DbSet<Flight> Flights { get; set; }
//        public DbSet<Passenger> Passengers { get; set; }
//        public DbSet<Seat> Seats { get; set; }
//        public DbSet<TicketFlight> TicketsFlight { get; set; }

//        public TicketsContext(DbContextOptions<TicketsContext> options) : base(options) { Database.EnsureCreated(); }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.ApplyConfiguration(new TicketFlightConfiguration());
//            builder.ApplyConfiguration(new AircraftConfiguration());
//            builder.ApplyConfiguration(new PassengerConfiguration());
//            builder.ApplyConfiguration(new AirportConfiguration());
//            builder.ApplyConfiguration(new BoardingPassConfiguration());
//            builder.ApplyConfiguration(new BookingConfiguration());
//            builder.ApplyConfiguration(new FlightConfiguration());
//            builder.ApplyConfiguration(new SeatConfiguration());
//            base.OnModelCreating(builder);
//        }
//    }
//}