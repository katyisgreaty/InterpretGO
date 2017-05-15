using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterpretGO.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool Claimed { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public int InterpreterId { get; set; }
        public Interpreter Interpreter { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Client FindClient(string ClientUserName)
        {
            Client thisClient = new InterpretGODbContext().Clients.FirstOrDefault(i => i.UserName == ClientUserName);
            return thisClient;
        }
    }
}
