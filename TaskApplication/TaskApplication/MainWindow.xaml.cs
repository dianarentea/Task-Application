using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskApplication.Models;

namespace TaskApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FolderList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = DataContext as ToDoListViewModel;
            if (viewModel != null)
            {
                var selectedTDL = FolderList.SelectedItem as ToDoList;
                if (selectedTDL != null)
                {
                    viewModel.OpenEditToDoListWindow(selectedTDL);
                }
            }
        }
    }
}
