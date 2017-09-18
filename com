Install-Package ASquare.WindowsTaskScheduler -Version 1.5.0
https://gesado.wordpress.com/2013/07/20/crear-tareas-programadas-desde-c/
https://escarbandocodigo.wordpress.com/2009/10/21/crear-tareas-programadas-desde-c/
https://www.codeproject.com/Articles/2407/A-New-Task-Scheduler-Class-Library-for-NET
http://pxm-software.com/programmatically-creating-scheduled-task-in-windows-task-scheduler/

https://www.nuget.org/packages/TaskScheduler/
Install-Package TaskScheduler -Version 2.6.1

https://www.nuget.org/packages/ASquare.WindowsTaskScheduler/
Install-Package ASquare.WindowsTaskScheduler -Version 1.5.0

            SchedulerResponse response = WindowTaskScheduler

https://www.nuget.org/packages/TaskScheduler/
Install-Package TaskScheduler -Version 2.6.1			
https://github.com/dahall/TaskScheduler/wiki/TriggerSamples
AllowHardTerminate
AllowDemandStart
RunOnlyIfNetworkAvailable
WakeToRun


Task Scheduler Problem (run whether user is logged on or not

			
    .Configure()
    .CreateTask("TaskName", "C:\\Test.bat")
    .RunDaily()
    .RunEveryXMinutes(10)
    .RunDurationFor(new TimeSpan(18, 0, 0))
    .SetStartDate(new DateTime(2017, 8, 8))
    .SetStartTime(new TimeSpan(8, 0, 0))
    .Execute();
	
	
	using (ScheduledTasks Tareas = new ScheduledTasks())
            {
                Task tarea = Tareas.CreateTask("Prueba");
                // archivo que vamos a ejecutar, escribimos la ruta completa
                tarea.ApplicationName = @"C:\Windows\System32\calc.exe";
                tarea.Comment = "Tarea que abre la calculadora";
                // configurar la cuenta con la que se ejecutara la tarea
                tarea.SetAccountInformation("usuario", "password");
                // limitar la duración de la tarea programada
                tarea.MaxRunTime = new TimeSpan(0, 15, 0);
                tarea.Creator = "Martín Reina";
                // prioridad de la tarea
                tarea.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
                // agregamos el disparador, la tarea se ejecutara diariamente a las 6 y 15 pm
                //tarea.Triggers.Add(new DailyTrigger(18, 15));
                int []dias =new int[] {1,15};
                tarea.Triggers.Add(new MonthlyTrigger(18,15,dias));
                tarea.Save();
           }
		   
//Comando para saber usuarios
net user

Microsoft Windows [Versión 6.3.9600]
(c) 2013 Microsoft Corporation. Todos los derechos reservados.

C:\Users\Administrador>net user

Cuentas de usuario de \\WIN-9MDMN4HIPB4

-------------------------------------------------------------------------------
Administrador            Invitado
Se ha completado el comando correctamente.


C:\Users\Administrador>
