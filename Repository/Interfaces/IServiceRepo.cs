using EgyptTouristWebSite.Models;

namespace EgyptTouristWebSite.Repository.Interfaces
{
    public interface IServiceRepo:IRepo<Service>
    {
        public List<Service> GetByCat(string cat);
    }
}
