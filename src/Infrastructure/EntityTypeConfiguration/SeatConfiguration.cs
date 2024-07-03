namespace Infrastructure.EntityTypeConfiguration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => new { s.AircraftId, s.SeatNo});
            builder.Property(s => s.SeatNo).HasMaxLength(4);
            builder.Property(s => s.AircraftId).IsRequired();
            builder.HasOne(s => s.Aircraft).WithMany(a => a.Seats).HasForeignKey(s => s.AircraftId);
            builder.Property(s => s.SeatNo).IsRequired();
        }
    }
}
