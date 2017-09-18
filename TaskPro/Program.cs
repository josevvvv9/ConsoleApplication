using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPro
{
    class Program
    {
        public static void crearTask()
        {

            //Traer el calendario 
            var listaFechas = calendario.calendarioColombia();

            //Definir horas y minutos 

            List<int> hora = new List<int>() { 9, 12, 17, 22 };
            List<int> minutos = new List<int>() { 30, 30, 30, 30 };

            //Traer la creacion de tarea programadas por fecha

            foreach (var item in listaFechas)
            {
                
            }


        }


        static void Main(string[] args)
        {
            
        }
    }
}
