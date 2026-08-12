using KBank.Models;
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

        public static void MenuLogado(Banco bancoAtual)
        {
            while (true)
            {
                Menus.Menuopc("Depositar", "Sacar", "Remover conta", "Exibir transações", "Sair da conta");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out int entrada);

                if (entrada == 5)//depois organizar melhor
                {
                    Console.WriteLine("==Saindo da conta=========");
                    Console.WriteLine("=============================");
                    break;
                }
                else if (entrada == 3)
                {
                    Console.WriteLine("Tem certeza que quer remover a conta[S/N]: ");
                    var resultado = Console.ReadLine();
                    if (resultado == "S" || resultado == "s")
                    {
                        Console.WriteLine("Nome do titular: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Numero da conta: ");
                        int.TryParse(Console.ReadLine(), out int number);
                        try
                        {
                            bancoAtual.RemoverConta(number, name);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (entrada == 3)
                {
                    //ExibirTransacoes();
                }
                //fazer os metodos: Depositar, Sacar e Exibir transações!
            }
        }
    }
}
