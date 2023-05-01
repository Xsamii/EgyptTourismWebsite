using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Repository
{
	public class AppUserRepo
	{
        DataBaseContext context;
        public AppUserRepo(DataBaseContext _Context)
        {
            context = _Context;
        }

		public void Add(AppUser a)
		{
			context.Users.Add(a);
			context.SaveChanges();
		}

		public void Delete(string id)
		{
			context.Remove(this.GetById(id));
			context.SaveChanges();

		}

		public List<AppUser> GetAll()
		{
			return context.Users.ToList();
		}

		public AppUser GetById(string id)
		{
			AppUser user = context.Users.FirstOrDefault(u => u.Id == id);
			return user;
		}
	}
}
