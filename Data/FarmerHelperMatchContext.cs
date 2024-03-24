using Microsoft.EntityFrameworkCore;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Data
{
    public class FarmerHelperMatchContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FarmerHelpRequest> FarmerHelpRequests { get; set; }
        public DbSet<HelperHelpOffer> HelperHelpOffers { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }
        public DbSet<InvasiveSpeciesType> InvasiveSpeciesTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public FarmerHelperMatchContext(DbContextOptions<FarmerHelperMatchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negotiation>()
                .HasOne(n => n.FarmerHelpRequest)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Negotiation>()
                .HasOne(n => n.HelperHelpOffer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FarmerHelpRequest>()
                .HasOne(f => f.OwnerUser)
                .WithMany();

            modelBuilder.Entity<HelperHelpOffer>()
                .HasOne(h => h.OwnerUser)
                .WithMany();
        }
    }
}