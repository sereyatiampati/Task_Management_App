using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_Management_App.Models;

namespace Task_Management_App.Connections
{
    public class DbConnection : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=TaskManager; User Id=sa; Password=Wamutitu#1; Encrypt=False; TrustServerCertificate=True");
            Console.WriteLine("Db creating");
        }
        
    }
}