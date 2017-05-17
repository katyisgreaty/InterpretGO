using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;

namespace InterpretGO.Controllers
{
    public class ClientsController : Controller
    {
        private InterpretGODbContext db = new InterpretGODbContext();
        public IActionResult Index()
        {
            return View(db.Clients.ToList());
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
    }
}
