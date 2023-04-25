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
using System.Windows.Forms;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;
using TaskApplication.ViewModels;
using Application = System.Windows.Application;
using MessageBox = System.Windows.Forms.MessageBox;
using RelayCommand = TaskApplication.Helpers.RelayCommand;
using Task = TaskApplication.Models.Task;

namespace TaskApplication
{
    internal class ToDoListViewModel : BaseVM
    {
        public ToDoListManager toDoListManager;
        public ToDoList doList;
        public TaskManager taskManager;
        public StatisticsManager statisticsManager;
        public ToDoListViewModel()
        {
            toDoListManager = new ToDoListManager();
            taskManager = new TaskManager();
            statisticsManager = new StatisticsManager();
            ItemsCollection = toDoListManager.ItemsCollection;
            TaskCollection=taskManager.TaskList;
            StatisticsCollection=statisticsManager.Statistics;
            FilteredTaskCollection = new ObservableCollection<Task>(TaskCollection);
            foreach (var task in TaskCollection)
            {
                task.DoneChanged += Task_DoneChanged;
            }
        }
        public ICommand OpenAddToDoListWindowCommand => new RelayCommand(OpenAddToDoListWindow);
        public ICommand OpenAddTaskWindowCommand=>new RelayCommand(OpenAddTaskWindow);
        public ICommand RemoveTaskCommand => new RelayCommand(RemoveTask);
        public ICommand UpdateTaskDoneCommand => new RelayCommand<bool>(UpdateTaskDone);
        public ICommand OpenFindTaskWindowCommand => new RelayCommand(OpenFindTaskWindow);
        public ICommand ExitApplicationCommand=> new RelayCommand(ExitApplication);
         public ICommand MoveUpTaskCommand => new RelayCommand(MoveUpTask);
         public ICommand MoveDownTaskCommand => new RelayCommand(MoveDownTask);
        public ICommand OpenEditTaskCommand=>new RelayCommand(OpenEditTaskWindow);
        public ICommand OpenEditToDoListWindowCommand => new RelayCommand(OpenEditToDoListWindow);
        public ICommand SortByDeadlineCommand => new RelayCommand(SortByDeadline);
        public ICommand SortByPriorityCommand => new RelayCommand(SortByPriority);
        public ICommand FilterByWorkCategoryCommand=> new RelayCommand(FilterByWorkCategory);
        public ICommand FilterByPersonalCategoryCommand => new RelayCommand(FilterByPersonalCategory);
        public ICommand FilterByOtherCategoryCommand => new RelayCommand(FilterByOtherCategory);
        public ICommand FilterBySchoolCategoryCommand => new RelayCommand(FilterBySchoolCategory);
        public ICommand FilterByOverdueCategoryCommand => new RelayCommand(FilterByOverdueCategory);
        public ICommand FilterByToDoCategoryCommand => new RelayCommand(FilterByToDoCategory);
        public ICommand ShwoAllTasksCommand=> new RelayCommand(ShowAllTasks);
        public ICommand ShowAboutStudentCommand=> new RelayCommand(ShowAboutStudent);
      public ICommand DeleteCompletedTaskCommand=> new RelayCommand(DeleteCompletedTask);
        
        //actiuni pe TDL-uri
        private void OpenAddToDoListWindow()
        {
            AddTDL addTDLWindow = new AddTDL();
            AddNewTDLViewModel addNewTDLViewModel = new AddNewTDLViewModel(toDoListManager);
            addTDLWindow.DataContext = addNewTDLViewModel;
            addTDLWindow.ShowDialog();
        }
        private void OpenEditToDoListWindow()
        {
            EditTDL editTDLWindow = new EditTDL();
            EditTDLViewModel editTDLViewModel = new EditTDLViewModel(toDoListManager,doList);
            editTDLWindow.DataContext = editTDLViewModel;
            editTDLWindow.ShowDialog();
        }

        //actiuni pe task-uri
        private void OpenAddTaskWindow()
        {
            AddTask addTaskWindow=new AddTask();
            AddNewTaskViewModel addNewTaskViewModel = new AddNewTaskViewModel(taskManager, statisticsManager);
            addTaskWindow.DataContext = addNewTaskViewModel;
            addTaskWindow.ShowDialog();
            FilteredTaskCollection = taskManager.TaskList;

        }
        private void OpenEditTaskWindow()
        {
            EditTask editTaskWindow = new EditTask();
            EditTaskViewModel editTaskViewModel = new EditTaskViewModel(SelectedTask, taskManager, statisticsManager);
            editTaskWindow.DataContext = editTaskViewModel;
            editTaskWindow.ShowDialog();
            FilteredTaskCollection = taskManager.TaskList;
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
            FilteredTaskCollection.Remove(SelectedTask);
        }
        private void MoveUpTask()
        {
            taskManager.MoveSelectedItem(-1, SelectedTask);
            FilteredTaskCollection = taskManager.TaskList;
        }
        private void MoveDownTask()
        {
            taskManager.MoveSelectedItem(1, SelectedTask);
            FilteredTaskCollection = taskManager.TaskList;
        }

        //sortari si filtrari de task-uri
        private void SortByDeadline()
        {
            //FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.OrderBy(x => x.Deadline));
            }
        }
        private void SortByPriority()
        {
            //FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.OrderBy(x => x.Priority));
            }
        }
        private void FilterByWorkCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Category == Task.CategoryType.Work));
            }
        }
        private void FilterByPersonalCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Category == Task.CategoryType.Personal));
            }
        }
        private void FilterByOtherCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Category == Task.CategoryType.Other));

            }
        }
        private void FilterBySchoolCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Category == Task.CategoryType.School));
            }
        }
        private void FilterByOverdueCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Deadline < DateTime.Now));
            }
        }
        private void FilterByToDoCategory()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Deadline > DateTime.Now));
            }
        }
        private void ShowAllTasks()
        {
            FilteredTaskCollection = TaskCollection;
            if (FilteredTaskCollection != null)
            {
                FilteredTaskCollection = new ObservableCollection<Task>(FilteredTaskCollection.Where(x => x.Name != null));

            }

        }

        private void Task_DoneChanged(object sender, EventArgs e)
        {
            if (sender is Task task)
            {
                UpdateTaskDone(task.Done);
            }
        }

        private void UpdateTaskDone(bool done)
        {
            if (SelectedTask != null)
            {
                taskManager.UpdateDone(SelectedTask);
                statisticsManager.UpdateCompletedCount(SelectedTask);
            }
        }
        private void DeleteCompletedTask()
        {
            var completedTasks = TaskCollection.Where(t => t.Done).ToList();
            foreach (var task in completedTasks)
            {
                TaskCollection.Remove(task);
                statisticsManager.DecreaseAllCount(task);
                FilteredTaskCollection.Remove(task);
            }
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }   
       private void ShowAboutStudent()
        {
            MessageBox.Show("Rentea Diana-Andreeea\nGroup 213\ndiana.rentea@student.unitbv.ro", "Informative box", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private ObservableCollection<Task> _filteredTaskCollection;
        public ObservableCollection<Task> FilteredTaskCollection
        {
            get { return _filteredTaskCollection; }
            set
            {
                _filteredTaskCollection = value;
                NotifyPropertyChanged(nameof(FilteredTaskCollection));
            }
        }

       



    }


}
