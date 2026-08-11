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
            var banco = new Banco();
            while (true)
            {
                Menus.Menuopc("Login", "Criar conta");
                int.TryParse(Console.ReadLine(), out int entrada);
                if (entrada == 1)
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine("Nome do titular da conta: ");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Numero da conta do titular: ");
                    int.TryParse(Console.ReadLine(), out int numero);
                    Console.WriteLine("=============================");
                    try
                    {
                        banco.Login(numero, nome);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    ContaBancaria.MenuLogado();
                }

                else if(entrada == 2)
                {
                    banco.CadastrarConta();
                }else if (entrada == 3)
                {
                    break;
                }
            }
        }
    }
}