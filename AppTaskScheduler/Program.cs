using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AppTaskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";
                td.Principal.LogonType = TaskLogonType.InteractiveToken;


                // Create a trigger that runs the last minute of this year
                td.Triggers.Add(new TimeTrigger
                {
                    StartBoundary = DateTime.Today + TimeSpan.FromHours(19)
                    + TimeSpan.FromMinutes(45) + TimeSpan.FromSeconds(00)
                });

                //Opciones de seguridad

                td.Settings.DisallowStartIfOnBatteries = false;
                td.Settings.Enabled = false;
                td.Settings.Hidden = false;

                td.Settings.IdleSettings.RestartOnIdle = false;
                td.Settings.IdleSettings.StopOnIdleEnd = false;

                td.Settings.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
                td.Settings.RunOnlyIfIdle = false;
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.StopIfGoingOnBatteries = false;

                td.Principal.RunLevel = TaskRunLevel.Highest;  //.LUA;

                td.Settings.AllowDemandStart = false;
                td.Settings.AllowHardTerminate = false;

                td.Settings.StartWhenAvailable = false;
                td.Settings.WakeToRun = false;





                // Add an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction("notepad.exe", null, null));



                // Register the task in the root folder
                const string taskName = "jo3243se";
                ts.RootFolder.RegisterTaskDefinition(taskName, td);




            }
        }
    }
}
