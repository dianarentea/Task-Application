using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApplication.Models;

namespace TaskApplication
{
    internal class ToDoListViewModel : BaseVM
    {
        public ToDoListViewModel()
        {
            ItemsCollection = new ObservableCollection<ToDoList>();
            ItemsCollection.Add(new ToDoList
            {
                Name = "Item1",
                SubCollection = new ObservableCollection<ToDoList>()
                {
                    new ToDoList{Name="b", SubCollection=new ObservableCollection<ToDoList>()
                    { new ToDoList() { Name="c", SubCollection=new ObservableCollection<ToDoList>()},
                      new ToDoList{Name="d", SubCollection=new ObservableCollection<ToDoList>()}
                    }
                    },
                    new ToDoList{Name="e", SubCollection=new ObservableCollection<ToDoList>()
                    {
                        new ToDoList{Name="f", SubCollection=new ObservableCollection<ToDoList>()},
                        new ToDoList{Name="g", SubCollection=new ObservableCollection<ToDoList>()}
                    }
                    }

                }
            });
            ItemsCollection.Add(new ToDoList()
            {
                Name = "Item2",
                SubCollection = new ObservableCollection<ToDoList>()
                {
                    new ToDoList{Name="h", SubCollection=new ObservableCollection<ToDoList>()
                    {
                        new ToDoList{Name="i", SubCollection=new ObservableCollection<ToDoList>()},
                        new ToDoList{Name="j", SubCollection=new ObservableCollection<ToDoList>()}
                    }
                    },
                }
            });

        }
        public ObservableCollection<ToDoList> ItemsCollection { get; set; }
        private ToDoList selectedItem;
        public ToDoList SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }
    }
}
