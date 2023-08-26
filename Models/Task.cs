using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_App.Models
{
    public enum Progress {
        InProgress = 1,
        Done = 2,
        Pending =3       
    }
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public Project project{ get; set; }
        public int ProjectId { get; set; }
        public Progress progress { get; set; } = Progress.Pending;
        public User user { get; set; }
        public int UserId { get; set; }

    }
}