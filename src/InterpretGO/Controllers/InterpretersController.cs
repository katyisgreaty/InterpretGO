using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InterpretGO.Controllers
{
    public class InterpretersController : Controller
    {
        private InterpretGODbContext db = new InterpretGODbContext();
        public IActionResult Index()
        {
            return View(db.Interpreters.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisInterpreter = db.Interpreters.FirstOrDefault(interpreters => interpreters.InterpreterId == id);
            return View(thisInterpreter);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Interpreter interpreter)
        {
            interpreter.UserName = User.Identity.Name;
            db.Interpreters.Add(interpreter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
