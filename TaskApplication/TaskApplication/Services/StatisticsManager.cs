using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApplication.Models;

namespace TaskApplication.Services
{
    internal class StatisticsManager:BaseVM
    {
        public StatisticsManager()
        {
            Statistics = new Statistics();
        }
        public Statistics Statistics { get; set; }
        TaskManager taskManager;
        public void UpdateStats()
        {
            Statistics.DueTodayCount = 0;
            Statistics.DueTomorrowCount = 0;
            Statistics.OverdueCount = 0;
            Statistics.CompletedCount = 0;
            Statistics.AllCount = 0;
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
    }
}
