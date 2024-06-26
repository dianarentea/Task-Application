﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApplication.Models
{
    internal class ToDoList:BaseVM
    {
        public ToDoList()
        {
            SubCollection=new ObservableCollection<ToDoList>();
        }
        public ObservableCollection<ToDoList> SubCollection { get; set; }
        public ObservableCollection<Task> TaskList { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }
       

    }
}
