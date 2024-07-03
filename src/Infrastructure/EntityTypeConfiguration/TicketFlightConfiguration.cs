namespace Infrastructure.EntityTypeConfiguration
{
    public class TicketFlightConfiguration : IEntityTypeConfiguration<TicketFlight>   
    {
        public void Configure(EntityTypeBuilder<TicketFlight> builder)
        {
            builder.HasKey(tf => tf.Id);
            builder.Property(tf => tf.FlightId).IsRequired();
            builder.Property(tf => tf.AircraftId).IsRequired();
            builder.Property(tf => tf.ScheduledDeparture).IsRequired();
            builder.Property(tf => tf.ScheduledArrival).IsRequired();
            builder.Property(tf => tf.Amount).IsRequired();
            builder.HasOne(tf => tf.Flight).WithMany(f => f.TicketsFlight).HasForeignKey(tf => tf.FlightId);
            builder.HasOne(tf => tf.Aircraft).WithMany(a => a.TicketsFlight).HasForeignKey(tf => tf.AircraftId);
            builder.HasMany(tf => tf.BoardingPasess).WithOne(bp => bp.TicketFlight).HasForeignKey(bp => bp.TicketFlightId);
        }
    }
}
