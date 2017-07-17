using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterpretGO.Models
{
    [Table("Clients")]
    public class Client
    {
        public Client()
        {
            this.Assignments = new HashSet<Assignment>();
        }

        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
