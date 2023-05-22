using CyberpunkPets.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CyberpunkPets.Data
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly PetShopContext _context;
        public AnimalRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Add(Animal entity)
        {
            var x = _context.Animals!.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(Animal entity)
        {
            var animal = _context.Animals!.FirstOrDefault(x => x.AnimalId == entity.AnimalId);
            if (animal != null)
                _context.Animals!.Remove(animal);
            _context.SaveChanges();

        }

        public Animal? Get(int id)
        {
            var animal =_context.Animals
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.AnimalId == id);
            if (animal != null)
                return animal;
            else
                return null;
        }

        public IQueryable<Animal> GetAll()
        {
            return _context.Animals
                .Include(x => x.Category)
                .Include(x => x.Comments);
        }
        public void Update(Animal entity)
        {
            var x = Get(entity.AnimalId);
            if (x == null)
                return;

            x.Name = entity.Name;
            x.Age = entity.Age;
            x.PictureName = entity.PictureName;
            x.Description = entity.Description;
            x.CategoryId = entity.CategoryId;

            _context.SaveChanges();
        }  
    }
}
