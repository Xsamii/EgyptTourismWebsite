using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;

namespace EgyptTouristWebSite.ViewModel
{
	public class TransportationVM:TransportationRepository
	{
		public Transportation transportation { get; set; }
        public TransportationVM(DataBaseContext _context):base(_context)
        {
            
        }
    }
}
