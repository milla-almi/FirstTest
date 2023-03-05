using Employee.Models;
using Employee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmployeeDbContext _db;

        public EmpController(EmployeeDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var SearchData = from b in _db.EmpData select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                SearchData = SearchData.Where(m => m.FirstName.Contains(SearchString));
                return View(SearchData);

            }
            IEnumerable<EmployementData> EmpDbLists = _db.EmpData;

            //var EmpDbLists = _db.EmpData.ToList();

            return View(EmpDbLists);
        }




        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployementData obj)
        {
            if(ModelState.IsValid)
            {
                _db.EmpData.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created successfully";
                return RedirectToAction("Index");
            }
          

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var EditFoundFromDb = _db.EmpData.Find(id);

            return View(EditFoundFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployementData obj)
        {

            if (ModelState.IsValid)
            {
                _db.EmpData.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee data edited successfully";
                return RedirectToAction("Index");

            }
            {
                NotFound();
            }


            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }
            var DeleteFromDb = _db.EmpData.Find(id);

            if (DeleteFromDb == null)
            {
                return NotFound();
            }

            return View(DeleteFromDb);
        }

        public IActionResult DeletePost(EmployementData obj)
        {
            if(obj == null)
            {
                return NotFound();
            }

            _db.EmpData.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
            //return View(obj);
            
        }

        

    }
}
