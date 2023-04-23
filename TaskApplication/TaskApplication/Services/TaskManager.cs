using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskApplication.Models;

namespace TaskApplication.Services
{
    internal class TaskManager:BaseVM
    {
        public ObservableCollection<Task> TaskList { get; set; }

        public TaskManager()
        {
            TaskList = new ObservableCollection<Task>
            {

                new Task("MVP", "Make a to-do list project", "High", Task.CategoryType.Personal, "High", new DateTime(2023, 4, 18),  Task.PriorityType.Minor, false),
                new Task("Angular", "Add styling in city page", "Low", Task.CategoryType.Work, "Low", new DateTime(2023, 4, 18), Task.PriorityType.None, false),
                new Task("BRTA", "Fix the bugs", "Medium", Task.CategoryType.Personal, "Medium", new DateTime(2023, 4, 19),Task.PriorityType.Major, false),
                new Task("C#", "Add a new feature", "High", Task.CategoryType.Work, "High", new DateTime(2023, 4, 20),  Task.PriorityType.Major, false),
                new Task("Django", "Add a sort method", "Low", Task.CategoryType.Personal, "Low", new DateTime(2023, 4, 21),  Task.PriorityType.Minor, false),
                new Task("Eclipse", "Add a new feature", "High", Task.CategoryType.Other, "High", new DateTime(2023, 4, 22), Task.PriorityType.None, false)
                
            };
        }
        public void AddTask(Task task)
        {
            TaskList.Add(task);
            NotifyPropertyChanged(nameof(TaskList));
        }
    }
}
