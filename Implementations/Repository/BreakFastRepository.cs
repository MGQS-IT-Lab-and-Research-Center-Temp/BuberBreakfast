using BuberBreakfast.Context;
using BuberBreakfast.Contracts.Repository;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Implementations.Repository
{
    public class BreakFastRepository : IBreakFastRepository
    {
        private readonly ApplicationContext  _context;
        public BreakFastRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public bool BreakFastExist(int id)
        {
            return _context.BreakFasts.Any(bf => bf.Id == id);
        }

        public bool BreakFastExist(string name)
        {
            return _context.BreakFasts.Any(bf => bf.Name == name);
        }

        public BreakFast Create(BreakFast breakfast)
        {
            _context.BreakFasts.Add(breakfast);
            _context.SaveChanges();
            return breakfast; 
        }

        public bool Delete(int id)
        {
            var breakfast = GetById(id);
            _context.BreakFasts.Remove(breakfast);
            _context.SaveChanges();
            return true;
        }
        public List<BreakFast> GetAll()
        {
            var breakfasts = _context.BreakFasts.Select( bf => new BreakFast
            {
                Id = bf.Id,
                Name = bf.Name,
                Description = bf.Description
            }).ToList();
            return breakfasts;
        }

        public BreakFast GetById(int id)
        {
            var breakfast = _context.BreakFasts.FirstOrDefault(bf => bf.Id == id);
            return breakfast;
        }

        public BreakFast Update(int id)
        {
            var breakfast = GetById(id);
            _context.BreakFasts.Update(breakfast);
            _context.SaveChanges();
            return breakfast;
        }
    }
}
