using CyberpunkPets.Data;
using CyberpunkPets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CyberpunkPets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private readonly IRepository<Animal> _animalRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Comment> _commentRepo;

        private readonly IWebHostEnvironment _host;
        public AdministratorController(IRepository<Animal> animalRepo, IRepository<Category> categoryRepo, IRepository<Comment> commentRepo, IWebHostEnvironment host)
        {
            _animalRepo = animalRepo;
            _categoryRepo = categoryRepo;
            _commentRepo = commentRepo;
            _host = host;
        }

        public IActionResult Admin(Category category)//main admin action 
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            if (category.CategoryId == 0)
                return View(_animalRepo.GetAll());
            else
                return View(_animalRepo.GetAll().Where(x => x.CategoryId == category.CategoryId));
        }

        [HttpGet]
        public IActionResult CreateNewAnimal()
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewAnimal(Animal animal)
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            if (animal.ProfilePic != null)
                animal.PictureName = PictureValidate(animal.ProfilePic!);
            if (ModelState.IsValid)
            {
                _animalRepo.Add(animal);
                return RedirectToAction("Admin");
            }
            return View(animal);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            if (_animalRepo.Get(id) == null)
                return NotFound();
            else
            {
                var animal = _animalRepo.Get(id);
                return View(animal);
            }
        }
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            ViewBag.Categories = _categoryRepo.GetAll();
            if (!ModelState.IsValid)
                return View(animal);
            if (animal.ProfilePic != null)
                animal.PictureName = PictureValidate(animal.ProfilePic!);

            _animalRepo.Update(animal);
            return RedirectToAction("Admin");

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Animal x = _animalRepo.Get(id)!;
            if (x == null)
                return NotFound();
            else
            {
                _animalRepo.Delete(x);
                return RedirectToAction("Admin");

            }
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("CreateNewAnimal");
            if (category.CategoryId != 0)
                return BadRequest();
            var x = _categoryRepo.GetAll().FirstOrDefault(x => x.Name!.ToLower() == category.Name!.ToLower().Trim());
            if (x != null)
                return Content("Category allready exists!");
            _categoryRepo.Add(new Category { CategoryId = category.CategoryId, Name = category.Name });
            return RedirectToAction("CreateNewAnimal");
        }
        private string PictureValidate(IFormFile file)
        {
            var wwwRootPath = _host.WebRootPath;
            var path = $"{wwwRootPath}/Images/ProfilePics/{file.FileName}";
            if (!System.IO.File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }
            return file.FileName;
        }
    }
}
