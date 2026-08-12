using System;
using System.Collections.Generic;
using System.Text;
using KBank.Enums;
using KBank.Exceptions;
using KBank.Utils;

namespace KBank.Models
{
    public class ContaBancaria
    {
        public int NumeroConta{ get; set; }
        public string NomeTitular { get; set; }
        public double Saldo { get; set; }
        public List<Transacoes> Transacoes = new List<Transacoes>();
        public static Banco bancoConta = new Banco();


        public ContaBancaria(int numeroConta, string nomeTitular, double saldo)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = saldo;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ValorNuloException("Valor nulo para essa operação!");
            }
            Saldo += valor;
            Console.WriteLine($"Deposito de R${valor} feito com sucesso!");
            var DataTransacao = DateTime.Now;
            var TipoTransacoes =  EnumTransacoes.Deposito;
            var transacao = new Transacoes(DataTransacao, valor, TipoTransacoes);
            Transacoes.Add(transacao);
        }

        public void Sacar(double valor)
        {
            if (valor <= 0 || valor > Saldo)
            {
                throw new ValorNuloException("Valor nulo para essa operação!");
            }
            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor} feito com sucesso!");
            Console.WriteLine("=============================");
            var DataTransacao = DateTime.Now;
            var TipoTransacoes = EnumTransacoes.Deposito;
            var transacao = new Transacoes(DataTransacao, valor, TipoTransacoes);
            Transacoes.Add(transacao);
        }

        public void ExibirTransacoes()
        {
            foreach (var transaction in Transacoes)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"Tipo de transação: {transaction.TipoTransacoes}");
                Console.WriteLine($"Valor da transação: {transaction.Valor}");
                Console.WriteLine($"Data da transação: {transaction.DataTransacao}");
                Console.WriteLine("=============================");
            }
        }

        public static void MenuLogado(Banco bancoAtual)
        {
            while (true)
            {
                Menus.Menuopc("Depositar", "Sacar", "Remover conta", "Exibir transações", "Sair da conta");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out int entrada);

                if(entrada == 5)//depois organizar melhor
                {
                    Console.WriteLine("==Saindo da conta=========");
                    Console.WriteLine("=============================");
                    break;
                }else if (entrada == 3)
                {
                    Console.WriteLine("Tem certeza que quer remover a conta[S/N]: ");
                    var resultado = Console.ReadLine();
                    if(resultado == "S" || resultado == "s")
                    {
                        Console.WriteLine("Nome do titular: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Numero da conta: ");
                        int.TryParse(Console.ReadLine(), out int number);
                        try
                        {
                            bancoAtual.RemoverConta(number, name);
                            break;
                        }catch (Exception ex){
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                //fazer os metodos: Depositar, Sacar e Exibir transações!
            }
        }
    }
}
