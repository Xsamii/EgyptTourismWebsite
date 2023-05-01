using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Repository
{
	public class AccommodationRepository:IAccommodationRepo
	{
		DataBaseContext context;
        public AccommodationRepository(DataBaseContext dbContext)
        {
			context = dbContext;
        }

        public void Add(Accommodation acc)
		{
			context.Accommodations.Add(acc);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			Accommodation acc = GetById(id);
			context.Accommodations.Remove(acc);
			context.SaveChanges();
		}

		public List<Accommodation> GetAll()
		{
			return context.Accommodations.ToList();

		}

        public List<Accommodation> GetAllWithType()
        {
            return context.Accommodations.Include(a => a.Type).ToList();
        }

        public Accommodation GetById(int id)
		{
			var acc = context.Accommodations.Include(a=>a.Type).FirstOrDefault(p => p.Id == id);
			return acc;
		}
        public List<Accommodation> GetByName(string name)
        {
            var accs = context.Accommodations.Include(a => a.Type).Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return accs;
        }
        public List<Accommodation> GetByCat(string category)
        {
            var accsList = context.Accommodations.Include(a => a.Type).Where(a => a.Type.Type == category).ToList();

            return accsList;
        }
    }
}
