using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterpretGO.Models;

namespace InterpretGO.ViewModels
{
    public class AssignmentsViewModel
    {
        public Assignment Assignment { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Interpreter> Interpreters { get; set; }
    }
}
