using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApplication.Models
{
    internal class Statistics:BaseVM
    {
        private int dueTodayCount;
        public int DueTodayCount
        {
            get { return dueTodayCount; }
            set
            {
                dueTodayCount = value;
                NotifyPropertyChanged(nameof(DueTodayCount));
                
            }
        }
        private int dueTomorrowCount;
        public int DueTomorrowCount
        {
            get { return dueTomorrowCount; }
            set
            {
                dueTomorrowCount = value;
                NotifyPropertyChanged(nameof(DueTomorrowCount));
            }
        }
        private int overdueCount;
        public int OverdueCount
        {
            get { return overdueCount; }
            set
            {
                overdueCount = value;
                NotifyPropertyChanged(nameof(OverdueCount));
            }
        }
        private int completedCount;
        public int CompletedCount
        {
            get { return completedCount; }
            set
            {
                completedCount = value;
                NotifyPropertyChanged(nameof(CompletedCount));
            }
        }
        private int allCount;
        public int AllCount
        {
            get { return allCount; }
            set
            {
                allCount = value;
                NotifyPropertyChanged(nameof(AllCount));
            }
        }
        public Statistics()
        {
            CompletedCount = 0;
            OverdueCount = 0;
            DueTodayCount = 0;
            DueTomorrowCount = 0;
            AllCount = 0;
        }

    }
}
