using System;
using KBank.Enums;
using KBank.Exceptions;
using KBank.Models;
using KBank.Utils;

namespace KBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus.MostrarMenu("Bem vindo ao KBank Financias!");
            Menus.Menuopc("Login", "Criar conta");
            int.TryParse(Console.ReadLine(), out int entrada);

            if (entrada == 1)
            {
                Console.WriteLine("teste!");//testes!
            }
            
        }
    }
}