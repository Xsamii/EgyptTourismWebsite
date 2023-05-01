using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Context;
namespace EgyptTouristWebSite.Repository
{
    public class TourGuideRepositry : ITourGuidRepo
    {
        private readonly DataBaseContext context;
        public TourGuideRepositry(DataBaseContext _context)
        {
            context = _context;
        }

        public void Add(TourGuide asd)
        {
            context.TourGuides.Add(asd);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TourGuide Tour = GetById(id);
            context.TourGuides.Remove(Tour);
            context.SaveChanges();
        }

        public List<TourGuide> GetAll()
        {
            return context.TourGuides.ToList();

        }

        public TourGuide GetById(int id)
        {
            var Tour = context.TourGuides.FirstOrDefault(p => p.Id == id);
            return Tour;
        }
    }
}
