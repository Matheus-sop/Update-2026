using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class SellersController : Controller
    {
        private readonly WebApplication2Context _context;


        private readonly SellerService _sellerService;
        private readonly DeparmentService _departmentService;
        public SellersController(SellerService sellerService, DeparmentService deparmentService, WebApplication2Context context)
        {
            _departmentService = deparmentService;
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
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
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

            return View(viewModel);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
