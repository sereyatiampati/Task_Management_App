using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_App.Models
{
    public class Project
    {
        public int ProjectId { get; set;}
        public string ProjectName { get; set;}
        public string Description {get; set;}
        public ICollection<Task> tasks {get; set;}
    }
}