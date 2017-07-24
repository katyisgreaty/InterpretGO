using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterpretGO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using InterpretGO.ViewModels;
using Microsoft.AspNetCore.Authorization;


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
            ClientsViewModel vm = new ClientsViewModel();
            List<string> languageList = new List<string> { "ASL", "PSE", "SEE", "Transliteration", "Other" };
            IEnumerable<SelectListItem> Languages =
                from l in languageList
                select new SelectListItem
                {
                    Text = l,
                    Value = l
                };
            vm.Languages = Languages;
            vm.Client = new Client();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            db.Clients.Add(client);
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
