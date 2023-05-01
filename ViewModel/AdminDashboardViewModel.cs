using EgyptTouristWebSite.Models;

namespace EgyptTouristWebSite.ViewModel
{
    public class AdminDashboardViewModel
    {
        public int NumUserAccounts { get; set; }
        public int NumAccommodations { get; set; }
        public int NumPlaces { get; set; }
        public int NumServices { get; set; }
        public int NumTravelAgencies { get; set; }
        public  List<AppUser> Users { get; set; } = new();

    }
}
