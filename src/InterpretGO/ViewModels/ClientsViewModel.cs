using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterpretGO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InterpretGO.ViewModels
{
    public class ClientsViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}
