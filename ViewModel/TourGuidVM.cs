using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;

namespace EgyptTouristWebSite.ViewModel
{
	public class TourGuidVM:TourGuideRepositry
	{
	public TourGuide tourGuide { get; set; }
        public TourGuidVM(DataBaseContext _context):base(_context)
        {
            
        }
    }
}
