using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApplication.Models
{
    internal class Task:BaseVM
    {
        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }
        public enum CategoryType 
        {   Work, 
            School,
            Personal,
            Other 
        }
        public enum PriorityType
        {
            Minor,
            Normal,
            Major,
            None
        }
        public Task(string name, string description, string status, CategoryType category,TaskPriority priority, DateTime deadline, PriorityType type, bool done)
        {
            Name = name;
            Status = status;
            Category = category;
            Priority = priority;
            Deadline = deadline;
            Description = description;
            Type = type;
            Done = done;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }
        private TaskPriority priority;
        public TaskPriority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                NotifyPropertyChanged("Priority");
            }
        }
        private CategoryType category;
        public CategoryType Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged("CategoryType");
            }
        }
        private DateTime deadline;
        public DateTime Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                NotifyPropertyChanged("Deadline");
            }
        }
        private PriorityType type;
        public PriorityType Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged("PriorityType");
            }
        }
        private bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                NotifyPropertyChanged("Done");
            }
        }


    }
}
