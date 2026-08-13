using System;
using KBank.Enums;
using KBank.Exceptions;
using KBank.Models;
using KBank.Utils;
using System.IO;

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
                Menus.Menuopc("Login", "Criar conta", "Sair");
                Console.Write("Opção: ");
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
                        var logado = banco.Login(numero, nome);
                        Menus.MenuLogado(banco, logado);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if(entrada == 2)
                {
                    try
                    {
                    banco.CadastrarConta();
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                else if (entrada == 3)
                {
                    Console.WriteLine("==Saindo do sistema=========");
                    break;
                }
            }
        }
    }
}