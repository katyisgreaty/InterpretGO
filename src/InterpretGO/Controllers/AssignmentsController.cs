using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;
using InterpretGO.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InterpretGO.Controllers
{
    public class AssignmentsController : Controller
    {
        // GET: /<controller>/
        private InterpretGODbContext db = new InterpretGODbContext();
        public IActionResult Index()
        {
            return View(db.Assignments.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            return View(thisAssignment);
        }

        //public IActionResult Create()
        //{

        //    //Not yet working!
        //    IEnumerable<SelectListItem> selectList =
        //       from c in db.Clients
        //       select new SelectListItem
        //       {
        //           Text = c.Name,
        //           Value = c.Name
        //       };
        //    AssignmentsViewModel avm = new AssignmentsViewModel();
        //    avm.Clients = selectList;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Assignment assignment)
        //{
        //    db.Assignments.Add(assignment);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Edit(int id)
        {
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            return View(thisAssignment);
        }

        [HttpPost]
        public IActionResult Edit(Assignment assignment)
        {
            db.Entry(assignment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            return View(thisAssignment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
