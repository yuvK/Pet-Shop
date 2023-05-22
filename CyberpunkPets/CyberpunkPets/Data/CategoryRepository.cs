using CyberpunkPets.Models;

namespace CyberpunkPets.Data
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly PetShopContext _context;
        public CategoryRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
                _context.Add(entity);
                _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            var x = _context.Categories.SingleOrDefault(x => x.CategoryId == entity.CategoryId);
            if (x != null)
            {
                foreach (var animal in _context.Animals)
                {
                    if(animal.CategoryId == x.CategoryId)
                    {
                        _context.Animals.Remove(animal);
                    }
                }
                _context.Categories.Remove(x);
            }
            _context.SaveChanges();
        }

        public Category? Get(int id)
        {
            return _context.Categories.SingleOrDefault(x => x.CategoryId == id);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }
        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
