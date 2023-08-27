using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;

namespace Task_Management_App.Controllers
{
    public class AdminController
    {
        // public AuthController newAuthController = new AuthController();
       
        public void AdminLanding(){

             ProjectController newProject = new ProjectController();
             TaskControllers newTask = new TaskControllers();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("1. View all Projects");
            System.Console.WriteLine("2. View all Users");
            System.Console.WriteLine("3. Add Project");
            System.Console.WriteLine("4. Delete Project");
            System.Console.WriteLine("5. Add Task ");
            System.Console.WriteLine("6. Delete Task");
            System.Console.WriteLine("7. Update Project");
            System.Console.WriteLine("8. exit");
            System.Console.WriteLine("Select way to proceed:..");

            var selected = Console.ReadLine();

            switch (selected)
            {
                case "1":
                    System.Console.WriteLine("All available projects");
                    newProject.GetAllProjects();
                    break;
                case "2":
                    System.Console.WriteLine("All available Users");
                    GetAllDevs();
                    break;
                case "3":
                    System.Console.WriteLine("Add Project");
                    newProject.CreatProject();
                    break;
                case "4":
                    System.Console.WriteLine("Delete Project here");
                    newProject.DeleteProject();
                    break;
                case "5":
                    System.Console.WriteLine("Add Task");
                    newTask.CreateTask();
                    break;
                case "6":
                    System.Console.WriteLine("Delete Task");
                    newTask.DeleteTask();
                    break;
                case "7":
                    System.Console.WriteLine("Update Project");
                    newProject.UpdateProject();
                    break;
                case "8":
                    break;
                default:
                    System.Console.WriteLine("invalid choice");
                    break;
            }

        }
        public void GetAllDevs(){
            var context = new DbConnection();
            var devs = context.Users.ToList();
            if (devs.Count > 0){
                System.Console.WriteLine("available Developers");
                foreach(var dev in devs){
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    System.Console.WriteLine($"{dev.UserID}. {dev.UserName}");
                }
            }
        }
    }
}