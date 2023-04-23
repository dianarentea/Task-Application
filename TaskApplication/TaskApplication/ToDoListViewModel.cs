using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;
using TaskApplication.ViewModels;
using RelayCommand = TaskApplication.Helpers.RelayCommand;
using Task = TaskApplication.Models.Task;

namespace TaskApplication
{
    internal class ToDoListViewModel : BaseVM
    {
        public ToDoListManager manager;
        public ToDoList doList;
        public TaskManager taskManager;
        public StatisticsManager statisticsManager;
        public ToDoListViewModel()
        {
            manager = new ToDoListManager();
            taskManager = new TaskManager();
            statisticsManager = new StatisticsManager();
            ItemsCollection = manager.ItemsCollection;
            TaskCollection=taskManager.TaskList;
            StatisticsManager=statisticsManager.Statistics;
          
        }
      public ICommand UpdateStatisticsCommand=>new RelayCommand(UpdateStatistics);
        public ICommand OpenAddToDoListWindowCommand => new RelayCommand(OpenAddToDoListWindow);
        public ICommand OpenAddTaskWindowCommand=>new RelayCommand(OpenAddTaskWindow);
        public ICommand RemoveTaskCommand => new RelayCommand(RemoveTask);
        private void OpenAddToDoListWindow()
        {
            AddTDL addTDLWindow = new AddTDL();
            AddNewTDLViewModel addNewTDLViewModel = new AddNewTDLViewModel(manager);
            addTDLWindow.DataContext = addNewTDLViewModel;
            addTDLWindow.ShowDialog();
           
             
        }
        private void OpenAddTaskWindow()
        {
            AddTask addTaskWindow=new AddTask();
            AddNewTaskViewModel addNewTaskViewModel = new AddNewTaskViewModel(taskManager);
            addTaskWindow.DataContext = addNewTaskViewModel;
            addTaskWindow.ShowDialog();
            //UpdateStatistics();
            //StatisticsManager = statisticsManager.Statistics;

        }
        private void RemoveTask()
        {
            if(SelectedTask!=null)
            TaskCollection.Remove(SelectedTask);
        }
        private void UpdateStatistics()
        {
           statisticsManager.UpdateStats();
        }
        public Statistics StatisticsManager { get; set; }
        private ObservableCollection<ToDoList> _itemsCollection;
        public ObservableCollection<ToDoList> ItemsCollection
        {
            get { return _itemsCollection; }
            set
            {
                _itemsCollection = value;
                NotifyPropertyChanged(nameof(ItemsCollection));
            }
        }
        private ObservableCollection<Task> _taskCollection;
        public ObservableCollection<Task> TaskCollection
        {
            get { return _taskCollection; }
            set
            {
                _taskCollection = value;
                NotifyPropertyChanged(nameof(TaskCollection));
            }
        }
        private Task _selectedTask;
        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                NotifyPropertyChanged(nameof(SelectedTask));
            }
        }

       



    }


}
