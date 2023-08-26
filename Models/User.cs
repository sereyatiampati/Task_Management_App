using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_App.Models
{
    public enum Role{
        Admin = 1,
        Developer =2
    }
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role role { get; set; } = Role.Developer;
        public Task task{ get; set; }
        
    }
}