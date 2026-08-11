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

        public void MenuLogado()
        {
            Menus.Menuopc("Depositar", "Sacar", "Remover conta");
        }
    }
}
