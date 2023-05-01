using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Context;
namespace EgyptTouristWebSite.Repository
{
    public class TravelAgencyRepository: IRepo<TravelAgency>
    {
        DataBaseContext context;

        public TravelAgencyRepository(DataBaseContext _context)
        {
            context = _context;
        }
        public void Add(TravelAgency newtravel)
        {
            context.TravelAgencies.Add(newtravel);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TravelAgency agency = GetById(id);
            context.TravelAgencies.Remove(agency);
            context.SaveChanges();
        }

        public List<TravelAgency> GetAll()
        {
            return context.TravelAgencies.ToList();
        }

        public TravelAgency GetById(int id)
        {
            var travelAgency = context.TravelAgencies.FirstOrDefault(p=>p.Id==id);
            return travelAgency;
        }
    }
}
