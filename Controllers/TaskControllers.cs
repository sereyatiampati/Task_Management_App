using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;


namespace Task_Management_App.Controllers
{
    public class TaskControllers
    {
        public ProjectController newProject = new ProjectController();
    //    public AuthController newAuth = new AuthController();
    public AdminController newAdmin= new AdminController();
        public void CreateTask(){
            System.Console.WriteLine("Enter task name");
            var name = Console.ReadLine();

            System.Console.WriteLine("task description");
            var desc = Console.ReadLine();

            System.Console.WriteLine("Select project to add to:...");
            newProject.GetAllProjects();
            var ProjectString = Console.ReadLine();
            if (int.TryParse(ProjectString, out int Project));

            System.Console.WriteLine("Select Dev to assign to: ...");
            newAdmin.GetAllDevs();
            var devString = Console.ReadLine();
            if (int.TryParse(devString, out int dev));

            var newTask = new Models.Task(){
                TaskName = name,
                Description = desc,
                ProjectId = Project,
                UserId = dev
            };

            var context = new Connections.DbConnection();
            context.Tasks.Add(newTask);
            context.SaveChanges();

            System.Console.WriteLine($"Task {newTask.TaskName} created successfully and assigned to userID: {newTask.UserId}");
        }
        public void GetAllTasks(){
            System.Console.WriteLine("Getting all available tasks");
            var context = new Connections.DbConnection();
            var tasks= context.Tasks.ToList();
            if(tasks.Count>0){
                foreach(var task in tasks){
                    Console.ForegroundColor= ConsoleColor.Green;
                    System.Console.WriteLine($"{task.TaskID}. {task.TaskName} | {task.Description} | {task.progress}");
                }
            }else{
                Console.ForegroundColor= ConsoleColor.Red;
                System.Console.WriteLine("no tasks found");
            }
            
        }
    }
}