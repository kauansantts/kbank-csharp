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

        public static void MenuLogado()
        {
            while (true)
            {
                Menus.Menuopc("Depositar", "Sacar", "Remover conta", "Sair da conta");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine(), out int entrada);

                if(entrada == 4)//depois organizar melhor
                {
                    Console.WriteLine("=============================");
                    break;
                }else if (entrada == 3)
                {
                    Console.WriteLine("Tem certeza que quer remover a conta[S/N]: ");
                    var resultado = Console.ReadLine();
                    if(resultado == "S")
                    {
                        Console.WriteLine($"Conta removida com sucesso!");
                        //Banco.
                        //remover a conta e avisar que o sistema vai fechar e tem que iniciar novamente para logar!
                    }
                }

            }
            //CREIO QUE MenuLogado TEM QUE ESTAR EM PROGRAM.CS E CADASTRAR CONTA TEM QUE TER UM TRY CATCH TBM ASSIM COMO LOGIN, PENSAR NISSO
        }
    }
}
