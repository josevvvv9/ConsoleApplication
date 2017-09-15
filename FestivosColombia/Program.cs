using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivosColombia
{
    class Program
    {

        public static List<DateTime> DiasFestivos(int Anio)
        {
            DateTime Pascua = calcularPascua(Anio);

            List<DateTime> diasFestivos = new List<DateTime>();

            IncluirFecha(ref diasFestivos, new DateTime(Anio, 1, 1)); //Primero de Enero
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 1, 6))); //Reyes magos
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 3, 19))); //San Jose
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Sunday, Pascua, true, false)); //Domingo de Ramos
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Thursday, Pascua, true)); //Jueves Santo
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Friday, Pascua, true)); //Viernes Santo
            IncluirFecha(ref diasFestivos, Pascua); //Pascua
            IncluirFecha(ref diasFestivos, new DateTime(Anio, 5, 1)); //Dia del trabajo


            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, Pascua).AddDays(42)); //Ascensión de Jesús
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, Pascua).AddDays(63)); //Corpus Christi
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, Pascua).AddDays(70)); //Sagrado Corazón


            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 6, 29))); //san Pedro y san Pablo
            IncluirFecha(ref diasFestivos, new DateTime(Anio, 7, 20)); //Grito de Independencia
            IncluirFecha(ref diasFestivos, new DateTime(Anio, 8, 7)); // Batalla de Boyacá
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 8, 15))); //Asuncion de la virgen
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 10, 12))); //Día de la Raza
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 10, 12))); //Todos los Santos
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 11, 1))); //Independencia de Cartagena
            IncluirFecha(ref diasFestivos, SiguienteDiaSemana(DayOfWeek.Monday, new DateTime(Anio, 11, 11))); //Independencia de Cartagena
            IncluirFecha(ref diasFestivos, new DateTime(Anio, 12, 8)); // Inmaculada Concepción
            IncluirFecha(ref diasFestivos, new DateTime(Anio, 12, 25)); // Navidad

            return diasFestivos;
        }

        private static void IncluirFecha(ref List<DateTime> ListaDias, DateTime fecha)
        {
            if (ListaDias.Contains(fecha) == false)
                ListaDias.Add(fecha);
        }

        private static DateTime SiguienteDiaSemana(DayOfWeek DiaSemana, DateTime fecha, bool haciaAtras = false, bool inclusive = true)
        {
            if (inclusive)
            {
                if (fecha.DayOfWeek == DiaSemana)
                {
                    return fecha;
                }
            }
            else
            {
                if (haciaAtras)
                    fecha = fecha.AddDays(-1);
                else
                    fecha = fecha.AddDays(1);
            }

            while (fecha.DayOfWeek != DiaSemana)
                if (haciaAtras)
                    fecha = fecha.AddDays(-1);
                else
                    fecha = fecha.AddDays(1);

            return fecha;
        }

        private static DateTime calcularPascua(int Anio)
        {

            int a, b, c, d, e;
            int m = 24, n = 5;


            if (Anio >= 1583 && Anio <= 1699)
            {
                m = 22;
                n = 2;
            }
            else if (Anio >= 1700 && Anio <= 1799)
            {
                m = 23;
                n = 3;
            }
            else if (Anio >= 1800 && Anio <= 1899)
            {
                m = 23;
                n = 4;
            }
            else if (Anio >= 1900 && Anio <= 2099)
            {
                m = 24;
                n = 5;
            }
            else if (Anio >= 2100 && Anio <= 2199)
            {
                m = 24;
                n = 6;
            }
            else if (Anio >= 2200 && Anio <= 2299)
            {
                m = 25;
                n = 0;
            }

            a = Anio % 19;
            b = Anio % 4;
            c = Anio % 7;
            d = ((a * 19) + m) % 30;
            e = ((2 * b) + (4 * c) + (6 * d) + n) % 7;


            int dia = d + e;


            if (dia < 10) //Marzo
                return new DateTime(Anio, 3, dia + 22);
            else //Abril
            {

                if (dia == 26)
                    dia = 19;
                else if (dia == 25 && d == 28 && e == 6 && a > 10)
                    dia = 18;
                else
                    dia -= 9;

                return new DateTime(Anio, 4, dia);
            }
        }

        public static List<string> diasHabiles()
        {

            List<string> diasHabiles = new List<string>();

            DateTime FechaIni = new DateTime(2017, 1, 1);
            DateTime FechaFin = new DateTime(2017, 12, 31);
            int xvDiferenciaFechas = (FechaFin - FechaIni).Days;

            int xvDiasHabiles = 0;

            for (int i = 0; i < xvDiferenciaFechas; i++)
            {

                //Console.WriteLine(string.Format("{0}{1}", "Dia a Validar: ", FechaIni.AddDays(i)));
                if (FechaIni.AddDays(i).DayOfWeek != DayOfWeek.Saturday && FechaIni.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                {
                    xvDiasHabiles = xvDiasHabiles + 1;
                    //Console.WriteLine(string.Format("{0}{1}", "Es Valido :", xvDiasHabiles.ToString()));
                    Console.WriteLine(FechaIni.AddDays(i));

                    foreach (var item in diasHabiles)
                    {
                        diasHabiles.Add(FechaIni.AddDays(i).ToString());
                    }
                }
                //Console.ReadLine();
            }

            return diasHabiles;
        }

        public static void calendarioColombia()
        {

            List<string> diasFestivoC = new List<string>();
            List<string> diasHabilesC = new List<string>();

            foreach (var item in DiasFestivos(2017))
            {
                //Console.WriteLine(item);
                diasFestivoC.Add(item.ToString());
            }


            foreach (var item in diasHabiles())
            {
                diasHabilesC.Add(item.ToString());
            }

           

            diasHabiles();

            Console.ReadLine();
        }
        static void Main(string[] args)
        {

            calendarioColombia();

            

        }


    }
}
