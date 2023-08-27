using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_App.Connections;
using Task_Management_App.Models;

namespace Task_Management_App.Controllers
{
    public enum Proceed{
        Login = 1,
        Register = 2
    }
    public class AuthController
    {
        public DevController newDevcontroller = new DevController();
        public AdminController newAdmin = new AdminController();
        public void LandingPage(){
            System.Console.WriteLine("Welcome to TASKIT");
            System.Console.WriteLine("---------------------------");
             foreach (Proceed proceed in Enum.GetValues(typeof(Proceed)))
            {
                Console.WriteLine($"{(int)proceed}. {proceed}"); 
            }
            System.Console.WriteLine("Select way to proceed");
            var input = Console.ReadLine();

            switch(input){
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                default:
                    break;
            }
        }
        public void Login(){
            System.Console.WriteLine("Proceeding with login ...");

            System.Console.WriteLine("Enter email to login: ");
            string email = Console.ReadLine();

            System.Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            ValidateUser(email, password);
        }

        //validating users
        public void ValidateUser(string email, string password){
            if (email != null && password != null){
                var context = new DbConnection();
                var user = context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null && password == user.Password){
                    if(user.role == Role.Admin){
                    System.Console.WriteLine("logged in successfully");
                    System.Console.WriteLine($"Welcome back Admin {user.UserName}");
                    newAdmin.AdminLanding();
                    }else{
                    System.Console.WriteLine("logged in successfully");
                    System.Console.WriteLine($"Welcome back Dev{user.UserName}");
                    newDevcontroller.DevMenu(user.UserID);
                    }
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("invalid credentials");
                    Login();
                }
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("email or password cannot be null");
            }
        }

        public void Register(){
            Console.WriteLine("Continue to register");
            System.Console.WriteLine("-------------------------");

            System.Console.WriteLine("Enter username");
            var name = Console.ReadLine();  

            System.Console.WriteLine("Enter Email");
            var email = Console.ReadLine(); 

            System.Console.WriteLine("Enter Password");
            var password = Console.ReadLine(); 

            Console.Write("Role (Admin/Developer): ");
            var roleInput = Console.ReadLine();
            Role role;
            // Enum.TryParse(roleInput, out role);
              if (roleInput == "1" || roleInput.ToLower() == "admin")
            {
                role = Role.Admin;
            }
            else if (roleInput == "2" || roleInput.ToLower() == "developer")
            {
                role = Role.Developer;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid role input. Defaulting to Developer role.");
                role = Role.Developer;
            }

            var newUser = new User(){
                UserName = name,
                Password = password,
                Email=  email,
                role = role 
            };

            var context = new DbConnection();
             context.Users.Add(newUser);
             context.SaveChanges();
             Console.ForegroundColor = ConsoleColor.DarkBlue;
             System.Console.WriteLine($"{newUser.UserName} you were registered successfully as {newUser.role}");

        }
        
    }
}