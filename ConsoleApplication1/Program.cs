using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void read()
        {
            /*
         int counter = 0;
         string line;

         // Read the file and display it line by line.
         System.IO.StreamReader file = new System.IO.StreamReader("d:\\test.txt");

         while ((line = file.ReadLine()) != null)
         {
             Console.WriteLine(line);

             counter++;
         }

         file.Close();
         Console.ReadKey();
         */

            //leer archivo en la posicion que se desee
            string[] lines = File.ReadAllLines(@"d:\\test.txt");

            foreach (string line in lines)
            {
                if (line.Length >= 0)
                {
                    var a = line.Substring(5, 18);
                    Console.WriteLine(a);

                }
                Console.ReadKey();
            }
            // Suspend the screen.

        }

        static void Main(string[] args)
        {
            read();
        }
    }
}
