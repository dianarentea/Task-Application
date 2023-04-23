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

namespace TaskApplication
{
    internal class ToDoListViewModel : BaseVM
    {
        public ToDoListManager manager;
        public ToDoList doList;
        public ToDoListViewModel()
        {
            manager = new ToDoListManager();
            ItemsCollection = manager.ItemsCollection;

          
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
       
        public ICommand OpenAddToDoListWindowCommand => new RelayCommand(OpenAddToDoListWindow);
        private void OpenAddToDoListWindow()
        {
            AddTDL AddTDLWindow = new AddTDL();
            AddNewTDLViewModel addNewTDLViewModel = new AddNewTDLViewModel(manager);
            AddTDLWindow.DataContext = addNewTDLViewModel;
            AddTDLWindow.ShowDialog();
             
        }
       



    }


}
