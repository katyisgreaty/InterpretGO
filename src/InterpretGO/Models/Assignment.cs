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
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public int InterpreterId { get; set; }
        public virtual Interpreter Interpreter { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public Client FindClient(int ClientId)
        {
            Client thisClient = new InterpretGODbContext().Clients.FirstOrDefault(i => i.ClientId == ClientId);
            return thisClient;
        }

        public Interpreter FindInterpreter(int InterpreterId)
        {
            Interpreter thisInterpreter = new InterpretGODbContext().Interpreters.FirstOrDefault(i => i.InterpreterId == InterpreterId);
            return thisInterpreter;
        }


    }
}
