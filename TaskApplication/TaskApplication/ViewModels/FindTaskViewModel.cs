using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;

namespace TaskApplication.ViewModels
{
    internal class FindTaskViewModel : BaseVM
    {
        public TaskManager _taskManager;

        public FindTaskViewModel(TaskManager taskManager)
        {
            this._taskManager = taskManager;
            FilteredTasks = new ObservableCollection<Task>();
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
        private ObservableCollection<Task> _filteredTasks;
        public ObservableCollection<Task> FilteredTasks
        {
            get { return _filteredTasks; }
            set
            {
                _filteredTasks = value;
                NotifyPropertyChanged("FilteredTasks");
            }
        }
        public ICommand FindTaskCommand => new RelayCommand(FindTasks);
        public ICommand CloseFindTaskWindowCommand => new RelayCommand(CloseFindTaskWindow);
        private void FindTasks()
        {
            IEnumerable<Task> tasks = _taskManager.TaskList;

            bool filterByName = !string.IsNullOrWhiteSpace(Name);
           

            if (filterByName)
            {
                tasks = tasks.Where(t => t.Name.ToLower().Contains(Name.ToLower()));
            }

            else
            {
                tasks = tasks.Where(t => t.Deadline.Date == SelectedDate.Date);
            }

            FilteredTasks.Clear();

            foreach (var task in tasks)
            {
                FilteredTasks.Add(task);
            }
            Name = string.Empty;
            SelectedDate = DateTime.Today;
        }
        private void CloseFindTaskWindow()
        {
            Application.Current.Windows.OfType<FindTask>().FirstOrDefault()?.Close();
        }

    }
}
