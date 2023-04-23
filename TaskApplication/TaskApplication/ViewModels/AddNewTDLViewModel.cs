using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;
using RelayCommand = TaskApplication.Helpers.RelayCommand;

namespace TaskApplication.ViewModels
{
    internal class AddNewTDLViewModel : BaseVM
    {
        private string _newItemName;
        private string _newItemImage;
        private ObservableCollection<string> _availableImages;
        public ToDoListManager _toDoListManager;
       
        public ToDoList item { get; set; }
        public AddNewTDLViewModel(ToDoListManager manager)
        {
           
            _availableImages = new ObservableCollection<string>()
        {
            "/TaskApplication;component/Images/ToDoListIcons/img1.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img2.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img3.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img4.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img5.jpg"
        };

            _newItemImage = _availableImages.FirstOrDefault();
            this._toDoListManager = manager;
        }

        public ObservableCollection<string> AvailableImages
        {
            get { return _availableImages; }
            set { _availableImages = value; NotifyPropertyChanged("AvailableImages"); }
        }

        public string NewItemName
        {
            get { return _newItemName; }
            set { _newItemName = value; NotifyPropertyChanged("NewItemName"); }
        }

        public string NewItemImage
        {
            get { return _newItemImage; }
            set { _newItemImage = value; NotifyPropertyChanged("NewItemImage"); }
        }

        public ICommand AddToDoListCommand => new RelayCommand(AddToDoList);
        private void AddToDoList()
        {
            ToDoList newItem = new ToDoList
            {
                Name = NewItemName,
                Image = NewItemImage,
                SubCollection = new ObservableCollection<ToDoList>()
            };


            _toDoListManager.AddItem(newItem);
            Application.Current.Windows.OfType<AddTDL>().FirstOrDefault()?.Close();
        }

        public ICommand SelectPreviousImageCommand => new RelayCommand(SelectPreviousImage);
        private void SelectPreviousImage()
        {
            int currentIndex = AvailableImages.IndexOf(NewItemImage);
            if (currentIndex > 0)
            {
                NewItemImage = AvailableImages[currentIndex - 1];
            }
        }
       

        public ICommand SelectNextImageCommand => new RelayCommand(SelectNextImage);
        private void SelectNextImage()
        {
            int currentIndex = AvailableImages.IndexOf(NewItemImage);
            if (currentIndex < AvailableImages.Count - 1)
            {
                NewItemImage = AvailableImages[currentIndex + 1];
            }
        }
    }

}
