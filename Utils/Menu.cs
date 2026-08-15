using KBank.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using KBank.Exceptions;
using System.Threading;

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

        public static void MenuLogado(Banco bancoAtual, ContaBancaria conta)
        {
            while (true)
            {
                Menus.Menuopc("Depositar", "Sacar", "Exibir/Alterar saldo", "Exibir transações", "Remover conta", "Sair da conta");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out int entrada);

                if (entrada == 6)//depois organizar melhor
                {
                    Console.WriteLine("==Processando=========");
                    Thread.Sleep(3000);
                    Console.WriteLine("==Saindo da conta=========");
                    Console.WriteLine("=============================");
                    break;
                }
                else if (entrada == 5)
                {
                    Console.WriteLine("Tem certeza que quer remover a conta[S/N]: ");
                    var resultado = Console.ReadLine();
                    if (resultado == "S" || resultado == "s")
                    {
                        try
                        {
                            Console.WriteLine("==Removendo conta=========");
                            Thread.Sleep(2000);
                            bancoAtual.RemoverConta(conta.NumeroConta, conta.NomeTitular);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (entrada == 4)
                {
                    Console.WriteLine("==Exibindo transações=========");
                    Thread.Sleep(2000);
                    conta.ExibirTransacoes();
                }else if(entrada == 1)
                {
                    try
                    {
                        Console.WriteLine("==Depositanto=========");
                        Console.Write("Valor a ser depositado:R$ ");
                        double.TryParse(Console.ReadLine(), out double valor);
                        Thread.Sleep(2200);
                        conta.Depositar(valor);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }else if (entrada == 2)
                {
                    try
                    {
                        Console.WriteLine("==Sacando=========");
                        Console.Write("Valor a ser sacado:R$ ");
                        double.TryParse(Console.ReadLine(), out double valor);
                        Console.WriteLine("==Processando=========");
                        Thread.Sleep(2200);
                        conta.Sacar(valor);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }else if (entrada == 3)
                {
                    try
                    {
                        conta.AlterarSaldo();
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
