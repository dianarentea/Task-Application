using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApplication.Models;

namespace TaskApplication.Services
{
    internal class StatisticsManager:BaseVM
    {
        TaskManager taskManager;
        public StatisticsManager()
        {
            Statistics = new Statistics();
            taskManager = new TaskManager();
            foreach (var task in taskManager.TaskList)
            {
                if (task.Deadline.Date == DateTime.Today)
                {
                    Statistics.DueTodayCount++;
                }
                else if (task.Deadline.Date == DateTime.Today.AddDays(1))
                {
                    Statistics.DueTomorrowCount++;
                }
                else if (task.Deadline.Date < DateTime.Today)
                {
                    Statistics.OverdueCount++;
                }
                if (task.Done)
                {
                    Statistics.CompletedCount++;
                }
                Statistics.AllCount++;
            }
        }
        public Statistics Statistics { get; set; }
        
        public void  IncreaseAllCount()
        {
             Statistics.AllCount++;
        }
        public void DecreaseAllCount(Task task)
        {
            if (task.Deadline == DateTime.Today)
            {
                Statistics.DueTodayCount--;
            }
            else if (task.Deadline == DateTime.Today.AddDays(1))
            {
                Statistics.DueTomorrowCount--;
            }
            else if (task.Deadline < DateTime.Today)
            {
                Statistics.OverdueCount--;
            }
            Statistics.AllCount--;

        }
        public void IncreaseEditTaskCount(Task task)
        {
            if (task.Deadline == DateTime.Today)
            {
                Statistics.DueTodayCount++;
            }
            else if (task.Deadline == DateTime.Today.AddDays(1))
            {
                Statistics.DueTomorrowCount++;
            }
            else if (task.Deadline < DateTime.Today)
            {
                Statistics.OverdueCount++;
            }
        }
        public void IncreaseCompletedCount()
        {
            Statistics.CompletedCount++;
        }
    }
}
