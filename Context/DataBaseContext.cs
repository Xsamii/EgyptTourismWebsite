using EgyptTouristWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EgyptTouristWebSite.Context
{
	public class DataBaseContext : IdentityDbContext<AppUser>
	{
		//public DbSet<Tourist> Tourists { get; set; }
		public DbSet<Accommodation> Accommodations { get; set; }
		public DbSet<InterestingPlace> InterestingPlaces { get; set; }
		public DbSet<Service> Services { get; set; }	
		public DbSet<Transportation> Transpotations { get; set; }
		public DbSet<TravelAgency> TravelAgencies { get; set; }
		public DbSet<TourGuide> TourGuides { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        
      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasIndex(e => e.UserName)
                .Is     Unique();
        }*/

    }
}
