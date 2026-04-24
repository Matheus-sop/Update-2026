using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class SellersController : Controller
    {
        private readonly WebApplication2Context _context;
        
        
        private readonly SellerService _sellerService;
        public SellersController(SellerService sellerService, WebApplication2Context context)
        {
            _sellerService = sellerService;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            //var departments = _context.Department.Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Name
                      
            //}).ToList();
            //ViewBag.Departments = new SelectList(_context.Department.ToList(), "Id", "Name");

            //var departmentsList = new List<SelectListItem>();
            //foreach (var department in _context.Department)
            //{
            //    var departmentItem = new SelectListItem(department.Name, department.Id.ToString());
            //    departmentsList.Add(departmentItem);
            //}

            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            //var department = _context.Department.Where(d => d.Id == seller.Department.Id).FirstOrDefault();
            //seller.Department = department;

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
