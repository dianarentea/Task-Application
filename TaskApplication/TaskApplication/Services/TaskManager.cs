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

                new Task("MVP", "Make a to-do list project", "High", Task.CategoryType.Personal, "High", new DateTime(2023, 4, 24),  Task.PriorityType.Minor, false),
                new Task("Angular", "Add styling in city page", "Low", Task.CategoryType.Work, "Low", new DateTime(2023, 4, 18), Task.PriorityType.None, false),
                new Task("BRTA", "Fix the bugs", "Medium", Task.CategoryType.Personal, "Medium", new DateTime(2023, 4, 24),Task.PriorityType.Major, false),
                new Task("C#", "Add a new feature", "High", Task.CategoryType.Work, "High", new DateTime(2023, 4, 20),  Task.PriorityType.Major, false),
                new Task("Django", "Add a sort method", "Low", Task.CategoryType.Personal, "Low", new DateTime(2023, 4, 25),  Task.PriorityType.Minor, false),
                new Task("Eclipse", "Add a new feature", "High", Task.CategoryType.Other, "High", new DateTime(2023, 4, 26), Task.PriorityType.None, false)
                
            };
        }
        public int GetIndex(Task task)
        {
            return TaskList.IndexOf(task);
        }
        public void AddTask(Task task)
        {
            TaskList.Add(task);
            NotifyPropertyChanged(nameof(TaskList));
        }
        public void AddEditedTask(Task task, int index)
        {
            if(index>=0 && index<=TaskList.Count-1)
                TaskList.Insert(index, task);

            NotifyPropertyChanged(nameof(TaskList));
        }
        public void UpdateDone(Task task)
        {
            task.Done = true;
            NotifyPropertyChanged(nameof(TaskList));
        }
        public void MoveSelectedItem(int direction, Task task)
        {
            if (task == null || TaskList.Count < 2)
                return;
            int oldIndex = TaskList.IndexOf(task);
            int newIndex = oldIndex + direction;
            if (newIndex < 0 || newIndex >= TaskList.Count)
                return;
            TaskList.Move(oldIndex, newIndex);
            NotifyPropertyChanged(nameof (TaskList));
        }

    }
}
