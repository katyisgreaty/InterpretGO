using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public IActionResult Edit(int id)
        {
            var thisInterpreter = db.Interpreters.FirstOrDefault(interpreters => interpreters.InterpreterId == id);
            return View(thisInterpreter);
        }

        [HttpPost]
        public IActionResult Edit(Interpreter interpreter)
        {
            db.Entry(interpreter).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisInterpreter = db.Interpreters.FirstOrDefault(interpreters => interpreters.InterpreterId == id);
            return View(thisInterpreter);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisInterpreter = db.Interpreters.FirstOrDefault(interpreters => interpreters.InterpreterId == id);
            db.Interpreters.Remove(thisInterpreter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
