using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;
using InterpretGO.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InterpretGO.Controllers
{
    public class AssignmentsController : Controller
    {
        // GET: /<controller>/
        private InterpretGODbContext db = new InterpretGODbContext();
        public IActionResult Index()
        {
            return View(db.Assignments.Include(assignments => assignments.Client).Include(assignments => assignments.Interpreter).ToList());
        }

        public IActionResult List()
        {
            return View(db.Assignments.Include(assignments => assignments.Client).Include(assignments => assignments.Interpreter).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            return View(thisAssignment);
        }

        public IActionResult Create()
        {
            List<SelectListItem> TerpIdList = new List<SelectListItem>();
            foreach (Interpreter terp in db.Interpreters)
            {
                TerpIdList.Add(new SelectListItem() { Text = terp.Name, Value = terp.InterpreterId.ToString() });
            }
            
            ViewBag.Terps = TerpIdList;

            List<SelectListItem> ClientIdList = new List<SelectListItem>();
            foreach (Client client in db.Clients)
            {
                ClientIdList.Add(new SelectListItem() { Text = client.Name, Value = client.ClientId.ToString() });
            }
            ViewBag.Clients = ClientIdList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            List<SelectListItem> TerpIdList = new List<SelectListItem>();
            foreach (Interpreter terp in db.Interpreters)
            {
                TerpIdList.Add(new SelectListItem() { Text = terp.Name, Value = terp.InterpreterId.ToString() });
            }
            ViewBag.Terps = TerpIdList;
            List<SelectListItem> ClientIdList = new List<SelectListItem>();
            foreach (Client client in db.Clients)
            {
                ClientIdList.Add(new SelectListItem() { Text = client.Name, Value = client.ClientId.ToString() });
            }
            ViewBag.Clients = ClientIdList;
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

        public IActionResult Claim(int id)
        {
            List<SelectListItem> TerpIdList = new List<SelectListItem>();
            foreach (Interpreter terp in db.Interpreters)
            {
                if(terp.Name != "No Interpreter Preference")
                {
                    TerpIdList.Add(new SelectListItem() { Text = terp.Name, Value = terp.InterpreterId.ToString() });
                }
            }
            ViewBag.Terps = TerpIdList;
            var thisAssignment = db.Assignments.FirstOrDefault(assignments => assignments.AssignmentId == id);
            return View(thisAssignment);
        }

        [HttpPost]
        public IActionResult Claim(Assignment assignment)
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
            db.Assignments.Remove(thisAssignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
