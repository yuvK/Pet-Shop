using CyberpunkPets.Data;
using CyberpunkPets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberpunkPets.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IRepository<Animal> _animalRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Comment> _commentRepo;

        public AnimalController(IRepository<Animal> animalRepo,
                                IRepository<Category> categoryRepo,
                                IRepository<Comment> commentRepo)
        {
            _animalRepo = animalRepo;
            _categoryRepo = categoryRepo;
            _commentRepo = commentRepo;
        }
        public IActionResult Index()
        {
            return View(_animalRepo.GetAll().OrderByDescending(a => a.Comments!.Count).Take(2));
        }
        [HttpGet]
        public IActionResult Catalog(Category category)
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            if (category.CategoryId == 0)
                return View(_animalRepo.GetAll());
            else
                return View(_animalRepo.GetAll().Where(x => x.CategoryId == category.CategoryId));
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            if (_animalRepo.Get(id) == null)
                return NotFound();
            else
            {
                return View(_animalRepo.Get(id));
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddComment(Comment comment/*, int id*/)
        {
            if (ModelState.IsValid)
            {
                _commentRepo.Add(comment/*new Comment { AnimalId = id, Content = comment.Content }*/);
                return RedirectToAction("Details", new { id = comment.AnimalId });

            }
            else
                return View("Details", _animalRepo.Get(comment.AnimalId));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteComment(int id)
        {
            Comment comment = _commentRepo.Get(id)!;
            if (comment == null)
                return NotFound();
            else
            {
                _commentRepo.Delete(comment);
                return RedirectToAction("Details", new { id = comment.AnimalId });
            }
        }
        //public IFormFile GetIFormFileFromString(string fileName, string fileContentType)
        //{
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "ProfilePics", fileName);
        //    var fileBytes = System.IO.File.ReadAllBytes(filePath);
        //    using (var memoryStream = new MemoryStream(fileBytes))
        //    {
        //        IFormFile formFile = new FormFile(memoryStream, 0, fileBytes.Length, "ProfilePic", fileName)
        //        {
        //            Headers = new HeaderDictionary(),
        //            ContentType = System.Net.Mime.MediaTypeNames.Image.Jpeg
        //        };
        //        return formFile;
        //    }
        //}
    }

}
