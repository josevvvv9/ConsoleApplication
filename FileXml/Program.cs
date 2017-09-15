using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FileXml
{
    class Program
    {

        public static void leerXml()
        {
            string file = "d:/testXml.xml";

            if (File.Exists(file))
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(file);

                    //Lectura a los nodos del file xml
                    XmlNodeList xPersonas = xDoc.GetElementsByTagName("personas");
                    XmlNodeList xLista = ((XmlElement)xPersonas[0]).GetElementsByTagName("nombre");

                    //Define las variables de salida 
                    string xEdad = "";
                    string xNombre = "";

                    foreach (XmlElement nodo in xLista)
                    {
                        xEdad = nodo.GetAttribute("edad");
                        xNombre = nodo.InnerText;
                        Console.WriteLine(xNombre);
                        Console.WriteLine(xEdad);

                        //Llamar funcion que registra en base de datos
                    }
                    Console.ReadKey();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    throw;
                }


            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            //llamado de funcion

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
        }
    }
}
