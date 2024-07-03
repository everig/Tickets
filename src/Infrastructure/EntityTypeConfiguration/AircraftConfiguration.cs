namespace Infrastructure.EntityTypeConfiguration
{
    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.Property(a => a.Id).HasMaxLength(8);
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id);
            builder.Property(a => a.Model).HasMaxLength(20);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Model).IsRequired();
            builder.Property(a => a.Range).IsRequired();
            builder.Property(a => a.MaxSeats).IsRequired();
            builder.Ignore(a => a.Flights);
            builder.Ignore(a => a.Seats);
            builder.Ignore(a => a.TicketsFlight);
            builder.HasMany(a => a.Seats).WithOne(s => s.Aircraft).HasForeignKey(s => s.AircraftId);
            builder.HasMany(a => a.Flights).WithOne(f => f.Aircraft).HasForeignKey(f => f.AircraftId);
            builder.HasMany(a => a.TicketsFlight).WithOne(tf => tf.Aircraft).HasForeignKey(tf => tf.AircraftId);
        }
    }
}
