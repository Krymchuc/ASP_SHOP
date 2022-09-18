using Microsoft.AspNetCore.Mvc;
using ASP_MVC_Shop.Models;

namespace ASP_MVC_Shop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogDbContext _dbContext;
        public CatalogController(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index1", _dbContext.CatalogItems.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create1", new CatalogItem());
        }
        [HttpPost]
        public IActionResult Create(CatalogItem data)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogItems.Add(new CatalogItem { Id = new Random().Next()/*(_dbContext.CatalogItems.Count()) + 2*/, Name =data.Name, Count = data.Count, Price = data.Price, Image=data.Image });
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create1", data);
            
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View(_dbContext.CatalogItems.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dbContext.CatalogItems.Remove(_dbContext.CatalogItems.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Init()
        {
            if (_dbContext.CatalogItems.Any()) 
                return Ok("Catalog is full");

            _dbContext.CatalogItems.AddRange(new List<CatalogItem>
            {
                new CatalogItem { Id=1, Name="Phone Samsung A50", Count=4, Price=5999.33, Image="https://content1.rozetka.com.ua/goods/images/original/166276365.jpg"},
                new CatalogItem { Id = 2, Name = "Laptop Lenovo", Count = 6, Price = 16978.93, Image="https://i.citrus.world/imgcache/size_800/uploads/shop/7/f/7f0589590a13d9b69d6dd13808ad4a31.jpg" },
                new CatalogItem { Id = 3, Name = "Computer Asus", Count = 9, Price = 25877.78, Image="https://largo.com.ua/storage/productImages/98697/r1i5Sa6CwyJ4ygXJ.jpg" }
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
