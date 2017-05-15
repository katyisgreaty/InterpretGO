using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace InterpretGO.Models
{
    public class Interpreter
    {
        [Key]
        public int InterpreterId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Specialty { get; set; }
        public string Certification { get; set; }
        public int Rate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public Interpreter()
        {

        }
    }

}
