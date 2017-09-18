using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appASquare
{
    class Program
    {
        public static void createTaskHourly(string NameTask, string App,
                                      int year, int month, int day,
                                      int hour, int minutes, int seconds)
        {
            SchedulerResponse response = WindowTaskScheduler
              .Configure()//(@"WIN-9MDMN4HIPB4\Usuario", "Clave");
              .CreateTask(NameTask, App)
              .RunHourly()//Una vez
              .SetStartDate(new DateTime(year, month, day))//Fecha
              .SetStartTime(new TimeSpan(hour, minutes, seconds))//hora
              .Execute();
        }
        public static void createTaskAllDaily(string NameTask, string Application,
                                    int year, int month, int day,
                                    int hour, int minutes, int seconds,
                                    int EveryXMinutes)
        {
            SchedulerResponse response = WindowTaskScheduler
              .Configure()
              .CreateTask(NameTask, Application)
              .RunDaily() //Todos los dias
              .RunEveryXMinutes(EveryXMinutes)
              //.RunDurationFor(new TimeSpan(18, 0, 0))//Durante
              .SetStartDate(new DateTime(year, month, day))//Fecha
              .SetStartTime(new TimeSpan(hour, minutes, seconds))//hora
              .Execute();
        }

        public static void deleteTaskName(string NameTask)
        {
            WindowTaskScheduler.Configure().DeleteTask(NameTask);
        }

        static void Main(string[] args)
        {
            
        }
    }
}



