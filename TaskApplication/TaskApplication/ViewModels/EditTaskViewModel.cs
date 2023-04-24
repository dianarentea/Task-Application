using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;
using Application = System.Windows.Application;

namespace TaskApplication.ViewModels
{
    internal class EditTaskViewModel:BaseVM
    {
        private Task _selectedTask;
        public Task SelectedTask
            {
                get { return _selectedTask; }
                set
                {
                    _selectedTask = value;
                    NotifyPropertyChanged("SelectedTask");
                }
            }

        public TaskManager _taskManager;
        public StatisticsManager _statisticsManager;
        public int index=0;
        public EditTaskViewModel(Task selectedTask, TaskManager taskManager, StatisticsManager statisticsManager )
        {
            this._selectedTask = selectedTask;
            this._taskManager = taskManager;
            this._statisticsManager = statisticsManager;
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                NotifyPropertyChanged("SelectedStatus");
            }
        }

        private string _selectedPriority;
        public string SelectedPriority
        {
            get { return _selectedPriority; }
            set
            {
                _selectedPriority = value;
                NotifyPropertyChanged("SelectedPriority");
            }
        }
        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }

        private Task.PriorityType _selectedType;
        public Task.PriorityType SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                NotifyPropertyChanged("SelectedType");
            }
        }

        private Task.CategoryType _selectedCategory;
        public Task.CategoryType SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged("SelectedCategory");
            }
        }
        public ICommand AddEditedTaskCommand => new RelayCommand(AddEditedTask);

       private void AddEditedTask()
        {
            int index = _taskManager.GetIndex(_selectedTask);
            _taskManager.TaskList.Remove(_selectedTask);
            _selectedTask.Name = Name;
            _selectedTask.Description = Description;
            _selectedTask.Status = SelectedStatus;
            _selectedTask.Priority = SelectedPriority;
            _selectedTask.Deadline = SelectedDate;
            _selectedTask.Type = SelectedType;
            _selectedTask.Category = SelectedCategory;

            _statisticsManager.IncreaseEditTaskCount(_selectedTask);
            _taskManager.AddEditedTask(_selectedTask, index);
          
            
            Application.Current.Windows.OfType<EditTask>().FirstOrDefault()?.Close();
        }
    }
}
