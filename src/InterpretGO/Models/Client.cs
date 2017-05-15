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
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public Client()
        {

        }
    }
}
