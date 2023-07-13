using JO20417123_ASPNETCore_L3.Data;
using JO20417123_ASPNETCore_L3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace JO20417123_ASPNETCore_L3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            var subCategories = new List<SubCategory>();
            var products = new List<Product>();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.SubCategories = new SelectList(subCategories, "Id", "Name");
            ViewBag.Products = new SelectList(products, "Id", "Name");
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = _context.SubCategories.Where(u => u.CategoryId == categoryId).ToList();
            return Json(subCategories);
        }
        public JsonResult GetProductByCategoryAndSubCategoryId(int categoryId, int subCategoryId)
        {
            var products = _context.Products.Where(u => u.CategoryId == categoryId && u.SubCategoryId == subCategoryId).ToList();
            return Json(products);
        }
    }
}