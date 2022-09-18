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
                _dbContext.CatalogItems.Add(new CatalogItem { Id = new Random().Next()/*(_dbContext.CatalogItems.Count()) + 2*/, Name =data.Name, Count = data.Count, Price = data.Price });
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create1", data);
            
        }
        [HttpGet]
        public IActionResult Init()
        {
            if (_dbContext.CatalogItems.Any()) 
                return Ok("Catalog is full");

            _dbContext.CatalogItems.AddRange(new List<CatalogItem>
            {
                new CatalogItem { Id=1, Name="Phone Samsung A50", Count=4, Price=5999.33},
                new CatalogItem { Id = 2, Name = "Laptop Lenovo", Count = 6, Price = 16978.93 },
                new CatalogItem { Id = 3, Name = "Computer Asus", Count = 9, Price = 25877.78 }
            });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
