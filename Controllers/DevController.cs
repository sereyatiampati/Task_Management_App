using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;

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
                    GetPendingTasks();
                    break;
                
                default:
                    break;
            }
        }
        public void GetCompletedTasks(int id){

            Console.WriteLine("viewing your completed tasks");
            var context = new DbConnection();
            var tasks = context.Tasks.Where(t => t.UserId == id).ToList();
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
        public void GetPendingTasks(){
            Console.WriteLine("viewing your pending tasks");
        }
        
    }
}