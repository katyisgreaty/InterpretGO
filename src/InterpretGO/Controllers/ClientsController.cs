using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;
using Microsoft.EntityFrameworkCore;

namespace InterpretGO.Controllers
{
    public class ClientsController : Controller
    {
        private InterpretGODbContext db = new InterpretGODbContext();
        public IActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisClient = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisClient = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisClient = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisClient = db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            db.Clients.Remove(thisClient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
