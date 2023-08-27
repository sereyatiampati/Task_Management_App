using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;
using Task_Management_App.Models;

namespace Task_Management_App.Controllers
{
    public class DevController
    {
        public void DevMenu(int id){
            Console.WriteLine("1. View all completed tasks");
            Console.WriteLine("2. View all Pending tasks");
            Console.WriteLine("Select way to proceed...");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Fetching your completed tasks");
                    GetCompletedTasks(id);
                    break;
                case "2":
                    Console.WriteLine("Fetching your pending tasks");
                    GetPendingTasks(id);
                    break;
                
                default:
                    break;
            }
        }
        public void GetCompletedTasks(int id){

            Console.WriteLine("viewing your completed tasks");
            var context = new DbConnection();
            var tasks = context.Tasks.Where(t => t.UserId == id && t.progress == Progress.Done).ToList();
            if(tasks.Count > 0){
                foreach(var task in tasks){
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{task.TaskID}. {task.TaskName} | {task.Description} | {task.progress}");
                }
            }else{
                Console.ForegroundColor= ConsoleColor.Red;
                System.Console.WriteLine($"no tasks found for userID: {id}");
            }

        }
        public void GetPendingTasks(int id){
            Console.WriteLine("viewing your pending tasks");

             var context = new DbConnection();
            var tasks = context.Tasks.Where(t => t.UserId == id && t.progress != Progress.Done).ToList();
            if(tasks.Count > 0){
                foreach(var task in tasks){
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{task.TaskID}. {task.TaskName} | {task.Description} | {task.progress}");

                UpdateTaskProgress();
                }
            }else{
                Console.ForegroundColor= ConsoleColor.Red;
                System.Console.WriteLine($"no tasks found for userID: {id}");
            }
        }
        public void UpdateTaskProgress(){
            Console.WriteLine("change task status to inprogress if started and done if completed");
            Console.WriteLine("select Task to update");
            var input = Console.ReadLine();
            int id = int.Parse(input);

             foreach (Progress value in Enum.GetValues(typeof(Progress)))
            {
                Console.WriteLine($"{(int)value}. {value}");
            }
            System.Console.WriteLine("show your  progress");
            var progress = int.Parse(Console.ReadLine());

            var context = new DbConnection();
            var Task_to_update = context.Tasks.FirstOrDefault(u=>u.TaskID == id);
            if (Task_to_update != null){
                Task_to_update.progress = (Progress)progress;
                context.SaveChanges();
            }else{
                System.Console.WriteLine("invalid option");
            }
            System.Console.WriteLine($"{Task_to_update.TaskName} status updated to {Task_to_update.progress}");
        }
        
    }
}