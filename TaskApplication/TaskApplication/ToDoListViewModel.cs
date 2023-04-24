using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            StatisticsCollection=statisticsManager.Statistics;
          
        }
        public ICommand OpenAddToDoListWindowCommand => new RelayCommand(OpenAddToDoListWindow);
        public ICommand OpenAddTaskWindowCommand=>new RelayCommand(OpenAddTaskWindow);
        public ICommand RemoveTaskCommand => new RelayCommand(RemoveTask);
        public ICommand UpdateTaskDoneCommand => new RelayCommand<bool>(UpdateTaskDone);
        public ICommand OpenFindTaskWindowCommand => new RelayCommand(OpenFindTaskWindow);
        public ICommand ExitApplicationCommand=> new RelayCommand(ExitApplication);

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
            statisticsManager.IncreaseAllCount();
        }
        private void OpenFindTaskWindow()
        {
            FindTask findTaskWindow=new FindTask();
            FindTaskViewModel findTaskViewModel=new FindTaskViewModel(taskManager);
            findTaskWindow.DataContext = findTaskViewModel;
            findTaskWindow.ShowDialog();
        }
        private void RemoveTask()
        {
            if(SelectedTask!=null)
            statisticsManager.DecreaseAllCount(SelectedTask);
            TaskCollection.Remove(SelectedTask);
        }
        private void UpdateTaskDone(bool done)
        {
            if (SelectedTask != null)
            {
                SelectedTask.Done = done;
                taskManager.UpdateDone(SelectedTask);
                statisticsManager.IncreaseCompletedCount();
            }
        }
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }


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
        private Statistics _statisticsCollection;
        public Statistics StatisticsCollection
        {
            get { return _statisticsCollection; }
            set
            {
                _statisticsCollection = value;
                NotifyPropertyChanged(nameof(Statistics));
            }
        }

       



    }


}
