using System;
using System.Collections.Generic;
using System.Text;

namespace KBank.Utils
{
    public static class Menus
    {
        public static void MostrarMenu(string opc1)
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", opc1.Length)));
            Console.WriteLine($"{opc1}");
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", opc1.Length)) + "\n");
        }

        public static void Menuopc(params string[]opc)
        {
            var i = 0;
            foreach(var item in opc)
            {  
                Console.WriteLine($"{i+1}- {item}");
                i++;

                if (i == opc.Length)
                {
                    Console.WriteLine("=============================");
                }
            }
        }
    }
}
