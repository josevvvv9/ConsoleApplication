using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllTaskScheduled
{
    public class taskScheduled
    {

        //Crear una tarea programada en windows
        public static void createTaskHourly(string NameTask, string App,
                                     int year, int month, int day,
                                     int hour, int minutes, int seconds)
        {

            using (TaskService ts = new TaskService())
            {
                var newTask = ts.NewTask();

                string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                newTask.Principal.UserId = user;
                // Create a trigger that runs the last minute of this year
                newTask.Triggers.Add(new TimeTrigger
                {
                    StartBoundary = new DateTime(year, month, day) + TimeSpan.FromHours(hour)
                    + TimeSpan.FromMinutes(minutes) + TimeSpan.FromSeconds(seconds)
                });

                //newTask.Actions.Add(new ExecAction(App));
                newTask.Actions.Add(new ExecAction("notepad"));
                ts.RootFolder.RegisterTaskDefinition(NameTask, newTask);

                ts.Dispose();

            }

        }
    }
}
