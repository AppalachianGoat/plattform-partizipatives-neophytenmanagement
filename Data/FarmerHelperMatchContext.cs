using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plattform_partizipatives_neophytenmanagement.Data
{
    public class FarmerHelperMatchContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FarmerHelpRequest> FarmerHelpRequests { get; set; }
        public DbSet<HelperHelpOffer> HelperHelpOffers { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }
        public DbSet<InvasiveSpeciesType> InvasiveSpeciesTypes { get; set; }

        public FarmHelperContext(DbContextOptions<FarmHelperContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negotiation>()
                .HasOne(n => n.FarmerHelpRequest)
                .WithMany()
                .HasForeignKey(n => n.FarmerHelpRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Negotiation>()
                .HasOne(n => n.HelperHelpOffer)
                .WithMany()
                .HasForeignKey(n => n.HelperHelpOfferId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}