using Microsoft.EntityFrameworkCore;

namespace P2P_volunteering.DAL.Model
{
    public partial class MainDBContext : DbContext, IMainDBContext
    {
        public MainDBContext()
        {
        }

        public MainDBContext(DbContextOptions<MainDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressLine).HasMaxLength(255);

                entity.Property(e => e.AdminDistrict)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AdminDistrict2)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Coords).IsRequired();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountryRegion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FormattedAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HouseNumber).HasMaxLength(255);

                entity.Property(e => e.Locality)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StreetName).HasMaxLength(255);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.Property(e => e.IdAddress).HasColumnName("Id_Address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Volunteer)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Volunteer_Address");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
