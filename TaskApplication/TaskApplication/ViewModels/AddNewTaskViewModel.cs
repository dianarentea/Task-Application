using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;

namespace TaskApplication.ViewModels
{
    internal class AddNewTaskViewModel : BaseVM
    {
        public TaskManager _taskManager;
        public StatisticsManager _statisticsManager;
        public AddNewTaskViewModel(TaskManager taskManager, StatisticsManager statisticsManager)
        {
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

        public ICommand AddTaskCommand => new RelayCommand(AddTask);
        private void AddTask()
        {
            var newTask = new Task(Name,
                                   Description,
                                   SelectedStatus,
                                   SelectedCategory,
                                   SelectedPriority,
                                   SelectedDate,
                                  (Task.PriorityType)SelectedType,
                                   false);
            _statisticsManager.IncreaseEditTaskCount(newTask);
           _statisticsManager.IncreaseAllCount();
            _taskManager.AddTask(newTask);
            Application.Current.Windows.OfType<AddTask>().FirstOrDefault()?.Close();
        }
    }
}
