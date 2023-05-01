using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;

namespace EgyptTouristWebSite.Repository
{
	public class ServiceRepository:IRepo<Service>
	{
		DataBaseContext context;
        public ServiceRepository(DataBaseContext _context)
        {
            context=_context;
        }
        public void Add(Service service)
		{
			context.Services.Add(service);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			Service service = GetById(id);
			context.Services.Remove(service);
			context.SaveChanges();
		}

		public List<Service> GetAll()
		{
			return context.Services.ToList();

		}

		public Service GetById(int id)
		{
			var service = context.Services.FirstOrDefault(p => p.Id == id);
			return service;
		}
	}
}
