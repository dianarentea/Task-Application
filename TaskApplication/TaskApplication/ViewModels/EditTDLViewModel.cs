using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using TaskApplication.Services;

namespace TaskApplication.ViewModels
{
    internal class EditTDLViewModel : BaseVM
    {
        private string _tdlName;
        private string _tdlImage;
        private ObservableCollection<string> _availableImages;
        private ToDoListManager _toDoListManager;
        private ToDoList _selectedTDL;
      
        public EditTDLViewModel(ToDoListManager toDoListManager, ToDoList selectedTDL)
        {

            _toDoListManager = toDoListManager;
            _selectedTDL = selectedTDL;
           
            _tdlName = selectedTDL.Name;

            _availableImages = new ObservableCollection<string>()
        {
            "/TaskApplication;component/Images/ToDoListIcons/img1.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img2.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img3.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img4.jpg",
            "/TaskApplication;component/Images/ToDoListIcons/img5.jpg"
        };
            int currentIndex = _availableImages.IndexOf(_selectedTDL.Image);
            if (currentIndex != -1)
            {
                _tdlImage = _availableImages[currentIndex];
            }
            else
            {
                _tdlImage = _selectedTDL.Image;
            }
            
        }
        public ToDoList SelectedTDL
        {
            get { return _selectedTDL; }
            set { _selectedTDL = value; NotifyPropertyChanged("ToDoList"); }
        }
        public ObservableCollection<string> AvailableImages
        {
            get { return _availableImages; }
            set { _availableImages = value; NotifyPropertyChanged("AvailableImages"); }
        }
        public string TDLName
        {
            get { return _tdlName; }
            set { _tdlName = value; NotifyPropertyChanged("TDLName"); }
        }
        public string TDLImage
        {
            get { return _tdlImage; }
            set { _tdlImage = value; NotifyPropertyChanged("TDLImage"); }
        }
        private void SaveTDL()
        {
            _selectedTDL.Name = TDLName;
            _selectedTDL.Image = TDLImage;

            // _toDoListManager.UpdateItem(_selectedTDL);
            Application.Current.Windows.OfType<EditTDL>().FirstOrDefault()?.Close();
        }
        private void DeleteTDL()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this TDL?",
                "Delete Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                _toDoListManager.RemoveItem(_selectedTDL);
                Application.Current.Dispatcher.Invoke(() => {
                    Application.Current.Windows.OfType<EditTDL>().FirstOrDefault()?.Close();
                });
            }
        }



        private void SelectPreviousImage()
        {
            int currentIndex = AvailableImages.IndexOf(TDLImage);
            if (currentIndex > 0)
            {
                TDLImage = AvailableImages[currentIndex - 1];
            }
        }
        private void SelectNextImage()
        {
            int currentIndex = AvailableImages.IndexOf(TDLImage);
            if (currentIndex < AvailableImages.Count - 1)
            {
                TDLImage = AvailableImages[currentIndex + 1];
            }
        }
        public ICommand SaveTDLCommand => new RelayCommand(SaveTDL);
        public ICommand DeleteTDLCommand => new RelayCommand(DeleteTDL);
        public ICommand SelectPreviousImageCommand => new RelayCommand(SelectPreviousImage);
        public ICommand SelectNextImageCommand => new RelayCommand(SelectNextImage);
    }

}
