using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApplication.Helpers;
using TaskApplication.Models;
using Task = TaskApplication.Models.Task;

namespace TaskApplication.Services
{
    internal class ToDoListManager:BaseVM
    {
        private ObservableCollection<ToDoList> itemsCollection;
        public ObservableCollection<ToDoList> ItemsCollection
        {
            get { return itemsCollection; }
            set
            {
                itemsCollection = value;
                NotifyPropertyChanged(nameof(ItemsCollection));
            }
        }
        public ObservableCollection<Task> TaskList;
        TaskManager taskManager;
        public ToDoListManager()
        {
            ItemsCollection = new ObservableCollection<ToDoList>();
            taskManager = new TaskManager();
            TaskList = taskManager.TaskList;     
            InitializeItemsCollection();
        

        }

        private void InitializeItemsCollection()
        {
            
            ItemsCollection.Add(new ToDoList
            {
                Name = "Item1",
                Image = "/TaskApplication;component/Images/ToDoListIcons/img1.jpg",
                SubCollection = new ObservableCollection<ToDoList>()
            {
                new ToDoList{Name="b", Image="/TaskApplication;component/Images/ToDoListIcons/img2.jpg",SubCollection=new ObservableCollection<ToDoList>()
                { new ToDoList() { Name="c", Image="/TaskApplication;component/Images/ToDoListIcons/img3.jpg", SubCollection=new ObservableCollection<ToDoList>()},
                  new ToDoList{Name="d", Image="",SubCollection=new ObservableCollection<ToDoList>() }
                }
                },
                new ToDoList{Name="e",Image="/TaskApplication;component/Images/ToDoListIcons/img4.jpg", SubCollection=new ObservableCollection<ToDoList>()
                {
                    new ToDoList{Name="f", Image="/TaskApplication;component/Images/ToDoListIcons/img2.jpg",SubCollection=new ObservableCollection<ToDoList>()},
                    new ToDoList{Name="g",Image="/TaskApplication;component/Images/ToDoListIcons/img3.jpg", SubCollection=new ObservableCollection<ToDoList>()}
                }
                }

            }
            });
            ItemsCollection.Add(new ToDoList()
            {
                Name = "Item2",
                Image = "/TaskApplication;component/Images/ToDoListIcons/img5.jpg",
                SubCollection = new ObservableCollection<ToDoList>()
            {
                new ToDoList{Name="h",Image="/TaskApplication;component/Images/ToDoListIcons/img1.jpg", SubCollection=new ObservableCollection<ToDoList>()
                {
                    new ToDoList{Name="i", Image="/TaskApplication;component/Images/ToDoListIcons/img4.jpg",SubCollection=new ObservableCollection<ToDoList>()},
                    new ToDoList{Name="j", Image = "/TaskApplication;component/Images/ToDoListIcons/img1.jpg", SubCollection=new ObservableCollection<ToDoList>()}
                }
                },
            }
            });

        }

        public void AddItem(ToDoList item)
        {
            ItemsCollection.Add(item);
            NotifyPropertyChanged(nameof(ItemsCollection));
        }
        public void RemoveItem(ToDoList item)
        {
            if (ItemsCollection.Contains(item))
            {
                ItemsCollection.Remove(item);
                NotifyPropertyChanged(nameof(ItemsCollection));

                foreach (ToDoList subItem in item.SubCollection)
                {
                    RemoveItem(subItem);
                }
            }
        }


    }


}
