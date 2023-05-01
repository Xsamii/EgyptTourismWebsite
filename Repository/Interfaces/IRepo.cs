namespace EgyptTouristWebSite.Repository.Interfaces
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T a);
        void Delete(int id);
    }
}
