using CyberpunkPets.Models;

namespace CyberpunkPets.Data
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly PetShopContext _context;
        public CommentRepository(PetShopContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            var x = _context.Comments.SingleOrDefault(x => x.CommentId == entity.CommentId);
            if (x != null)
            _context.Comments.Remove(x);
            _context.SaveChanges();
        }

        public Comment? Get(int id)
        {
            return _context.Comments.SingleOrDefault(c => c.CommentId == id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }
        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
