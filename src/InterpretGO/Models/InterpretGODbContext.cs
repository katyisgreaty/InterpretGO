using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterpretGO.Models
{
    public class InterpretGODbContext : IdentityDbContext<ApplicationUser>
    {
        public InterpretGODbContext()
        {
        }
        //Both models appear in the database when migration is updated!
        public virtual DbSet<Assignment> Assignments { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Interpreter> Interpreters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Database is called MrFixIt
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MrFixIt;integrated security=True");
        }

        public InterpretGODbContext(DbContextOptions<InterpretGODbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
