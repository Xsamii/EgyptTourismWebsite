using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EgyptTouristWebSite.Repository
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly DataBaseContext _context;
        public ServiceRepo(DataBaseContext context)
        {
            _context = context;
        }
        public void Add(Service a)
        {
            _context.Services.Add(a);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Service serviceToDelete = GetById(id);
            _context.Services.Remove(serviceToDelete);
            _context.SaveChanges();
        }

        public List<Service> GetAll()
        {
           return _context.Services.Include(s=>s.Type).ToList();
        }

        public List<Service> GetByCat(string cat)
        {
            var services = _context.Services.Include(s => s.Type).Where(s => s.Type.Type == cat).ToList();
            return services;
        }

        public Service GetById(int id)
        {
            return _context.Services.Include(s => s.Type).FirstOrDefault(s => s.Id == id);
        }
    }
}
