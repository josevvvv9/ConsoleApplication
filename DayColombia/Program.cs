using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayColombia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime FechaIni = new DateTime(2017, 1, 1);
            DateTime FechaFin = new DateTime(2017, 12, 31);
            int xvDiferenciaFechas = (FechaFin - FechaIni).Days;

            int xvDiasHabiles = 0;

            for (int i = 0; i < xvDiferenciaFechas; i++)
            {

                Console.WriteLine(string.Format("{0}{1}", "Dia a Validar: ", FechaIni.AddDays(i)));
                if (FechaIni.AddDays(i).DayOfWeek != DayOfWeek.Saturday && FechaIni.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                {
                    xvDiasHabiles = xvDiasHabiles + 1;
                    Console.WriteLine(string.Format("{0}{1}", "Es Valido :", xvDiasHabiles.ToString()));
                    }
                //Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
    }

