using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;

namespace EgyptTouristWebSite.ViewModel
{
	public class TravelAgencyVM:TravelAgencyRepository
	{
		public TravelAgency travelAgency { get; set; }
		public TravelAgencyVM(DataBaseContext _context) : base(_context)
		{
		}

	}
}
