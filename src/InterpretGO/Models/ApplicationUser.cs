using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InterpretGO.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Client Client { get; set; }
        public Interpreter Interpreter { get; set; }
    }

    
}