using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Repository
{
    public class TravelAgencyRepo : ITravelAgencyRepo
    {
        private readonly DataBaseContext _context;
        public TravelAgencyRepo(DataBaseContext context)
        {

            _context = context;

        }
        public void Add(TravelAgency a)
        {
            _context.TravelAgencies.Add(a);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteItem = GetById(id);
            _context.TravelAgencies.Remove(deleteItem);
        }

        public List<TravelAgency> GetAll()
        {
            return _context.TravelAgencies.Include(t => t.TourGuide).ToList();
        }

        public TravelAgency GetById(int id)
        {
            return _context.TravelAgencies.Include(t => t.TourGuide).FirstOrDefault(t => t.Id == id);
        }
    }
}
