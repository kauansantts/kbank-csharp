using System;
using System.Collections.Generic;
using System.Text;
using KBank.Enums;
using KBank.Exceptions;
using KBank.Utils;
using System.IO;
using System.Linq;
using System.Threading;

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
            Console.WriteLine($"Deposito de R${valor.ToString("F")} feito com sucesso!");
            Console.WriteLine("=============================");
            var DataTransacao = DateTime.Now;
            var TipoTransacoes =  EnumTransacoes.Deposito;
            var transacao = new Transacoes(DataTransacao, valor, TipoTransacoes);
            Transacoes.Add(transacao);//ADD na lista local
            //add no arquivo
            SalvarDadosArquivo();
        }

        public void Sacar(double valor)
        {
            if (valor <= 0 || valor > Saldo)
            {
                throw new ValorNuloException("Valor nulo para essa operação!");
            }
            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor.ToString("F")} feito com sucesso!");
            Console.WriteLine("=============================");
            var DataTransacao = DateTime.Now;
            var TipoTransacoes = EnumTransacoes.Saque;
            var transacao = new Transacoes(DataTransacao, valor, TipoTransacoes);
            Transacoes.Add(transacao);
            SalvarDadosArquivo();
        }

        public void ExibirTransacoes()
        {
            if (Transacoes.Count == 0)
            {
                Console.WriteLine("Você ainda nao efetuou transações!");
                Console.WriteLine("=============================");
                return;
            }
            
            foreach (var transaction in Transacoes)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"Tipo de transação: {transaction.TipoTransacoes}");
                Console.WriteLine($"Valor da transação: R${transaction.Valor.ToString("F")}");
                Console.WriteLine($"Data da transação: {transaction.DataTransacao}");
                Console.WriteLine("=============================");
            }
        }

        public void SalvarDadosArquivo()
        {
            var path = @$"C:\Users\kauan\Documents\DEV\C#\KBank\Contas\conta_{NumeroConta}.txt";

            List<string> dados = new List<string>();
            dados.Add(NumeroConta.ToString());
            dados.Add(NomeTitular);
            dados.Add(Saldo.ToString());

            foreach (var transaction in Transacoes)
            {
                string Transferencia = $"{transaction.TipoTransacoes};{transaction.Valor};{transaction.DataTransacao}";
                dados.Add(Transferencia);
            }

            File.WriteAllLines(path, dados);
        }

        public void AlterarSaldo()
        {
            Console.WriteLine("==Saldo==========");
            Console.WriteLine(Saldo.ToString("F"));

            Console.Write("Deseja alterar seu saldo?[S/N] ");
            var resposta = Console.ReadLine();
            if (resposta == "s" || resposta == "S")
            {
                Console.WriteLine("=============================");
                Console.Write($"Saldo[R${Saldo}]:R$ ");
                var retorno = double.TryParse(Console.ReadLine(), out double novoSaldo);
                if (novoSaldo < 0 || retorno == false)
                {
                    throw new ValorNuloException("Valor nulo para essa operação!");
                }
                Saldo = novoSaldo;
                Console.WriteLine("==Processando=========");
                Thread.Sleep(1500);
                Console.WriteLine("Saldo alterado com sucesso");
                Console.WriteLine($"Novo saldo de: R${Saldo}");
                Console.WriteLine("=============================");
                var DataTransacao = DateTime.Now;
                var TipoTransacoes = EnumTransacoes.AlteraçãoSaldo;
                var transacao = new Transacoes(DataTransacao, novoSaldo, TipoTransacoes);
                Transacoes.Add(transacao);
                SalvarDadosArquivo();
            }
        }
    }
}
