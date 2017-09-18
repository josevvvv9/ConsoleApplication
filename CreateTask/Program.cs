using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace CreateTask
{
   public class Program
    {

        public static Timer aTimer;

        #region Inicio
        public static void inicio()
        {

            //Inicia envio de archivo xml
            wcfEnvio();

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 60000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += wcfValidacion;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = false;

            // Start the timer
            aTimer.Enabled = true;

        }
        #endregion

        #region Envio
        public static void wcfEnvio()
        {
            try
            {
                ServiceReference1.IService1 proxy = new ServiceReference1.Service1Client();
                proxy.GetData(1);
                Console.Write("Envio file xml");
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
                throw;

            }
        }
        #endregion

        #region Validacion
        public static void wcfValidacion(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Validacion");
            /*Se lee el arhcivo xml en la clave de la respuestas si pasa algun registro con error
              se enviar correo electronico al afiliados con las transferencia rechazadas*/
            wcfRespuesta();
        }
        #endregion

        #region Respuesta
        public static void wcfRespuesta()
        {
            //Envio de correo de transfercias con codigo SOO satifactoria al afiliado
            Console.WriteLine("Respuesta");
            Console.ReadKey();
           
        }
        #endregion


        static void Main(string[] args)
        {
            
            /*
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            */

            //llamado de funcion
            inicio();

            /*
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            */
            
        }
        }
    }

