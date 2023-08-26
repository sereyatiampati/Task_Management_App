using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;
using Task_Management_App.Models;

namespace Task_Management_App.Controllers
{
    public class ProjectController
    {
        public void CreatProject(){
            Console.WriteLine("Add New Project here --");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Enter Project name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter Project description");
            var description = Console.ReadLine();

            var newProject = new Project(){
                ProjectName = name,
                Description = description
            };

            var context = new DbConnection();
             context.Projects.Add(newProject);
             context.SaveChanges();
             Console.WriteLine($"Project: {newProject.ProjectName} created");
        }
    }
}
