using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppCrud.Data;

namespace WepAppCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Result = _context.Employees.Include(x => x.department).OrderBy(x => x.EmployeeName).ToList();
            return View(Result);
        }

        public IActionResult Create() {

            ViewBag.Departments = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            ImageUpload(model);

            if (ModelState.IsValid)
            {

                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View(model);

        }

      

        
        public IActionResult Edit(int? id) {

            ViewBag.Departments = _context.Departments.OrderBy(x => x.DepartmentName).ToList();
            var result = _context.Employees.Find(id);

           return View("Create",result);


        }


        [HttpPost]
        [ValidateAntiForgeryToken ]
        public IActionResult edit(Employee model) {
            ImageUpload(model);

            if (ModelState.IsValid) {

                _context.Employees.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult delete(int? id)
        {

            
            var result = _context.Employees.Find(id);
            if (result != null) { 
                
               _context.Employees.Remove(result);
                _context.SaveChanges();
                
            
            }
            return RedirectToAction(nameof(Index));

        }





        private void ImageUpload(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {

                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "photos", imageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.ImageUser = imageName;

            }
            else if (model.ImageUser == null && model.EmployeeId == null)
            {

                model.ImageUser = "Black Clover.png";

            }
            else
            {

                model.ImageUser = model.ImageUser;

            }
        }
    }
}
