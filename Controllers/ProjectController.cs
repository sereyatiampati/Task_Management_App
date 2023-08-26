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
        public void GetAllProjects(){
            
            Console.WriteLine("fetching all available Projects---");
            
            Console.WriteLine("--------------------------------------");

            var context = new DbConnection();
            var projects = context.Projects.ToList();

            foreach(var project in projects){
                
                Console.WriteLine($"{project.ProjectId}. {project.ProjectName} description: {project.Description}");
            }
        }
         public void DeleteProject(){
            Console.WriteLine("deleting Project");
            GetAllProjects();
            Console.WriteLine("Select Project to delete");
            var input = Console.ReadLine();
            int id = int.Parse(input);

            var context = new DbConnection();
            var project_to_delete = context.Projects.FirstOrDefault(u => u.ProjectId == id);
            if(project_to_delete != null){
                context.Projects.Remove(project_to_delete);
                context.SaveChanges();
                Console.WriteLine($"project {project_to_delete.ProjectName} deleted");
            }else{
                Console.WriteLine("Project option not available");
            }
         }

         public void UpdateProject(){
            Console.WriteLine("Update Project here");
            GetAllProjects();

            Console.WriteLine("select Project to update");
            var input = Console.ReadLine();
            int id = int.Parse(input);

            var context = new DbConnection();
            var project_to_update = context.Projects.FirstOrDefault(u=>u.ProjectId == id);
            if(project_to_update != null){
                Console.WriteLine("Input new ProjectName:");
                var newProjectName = Console.ReadLine();

                if(newProjectName =="" || newProjectName ==" "){
                    project_to_update.ProjectName = project_to_update.ProjectName;
                }else{
                    project_to_update.ProjectName = newProjectName;
                }

                Console.WriteLine("Input new Project description:");
                var newDescription = Console.ReadLine();
                if(newDescription =="" || newDescription ==" "){
                    project_to_update.Description = project_to_update.Description;
                }else{
                    project_to_update.Description = newDescription;
                }

                context.SaveChanges();
                Console.WriteLine($"project: {project_to_update.ProjectName} updated successfully");
            }
         }
    }
}
