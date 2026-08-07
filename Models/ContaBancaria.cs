using System;
using System.Collections.Generic;
using System.Text;
using KBank.Services;

namespace KBank.Models
{
    class ContaBancaria
    {
        public int NumeroConta{ get; set; }
        public string NomeTitular { get; set; }
        public double Saldo { get; set; }

        public List<ContaBancaria> Contas = new List<ContaBancaria>();

        public ContaBancaria(int numeroConta, string nomeTitular, double saldo)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = saldo;
        }

        public void CadastrarConta()
        {
            Console.WriteLine("==Gerando numero de conta=========");
            var NumeroConta = new Random().Next(1000, 9999);
            foreach (var conta in Contas)
            {
                if(conta.NumeroConta == NumeroConta)
                {
                    //criar exceção de conta ja existente para tratar la em services!
                }
                else
                {
                    NumeroConta = 0;
                    break;
                }
            }
            Console.WriteLine($"Número da conta: {NumeroConta}");
            Console.WriteLine("Digite o nome do titular: ");
            NomeTitular = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial: ");
            double.TryParse(Console.ReadLine(), out double Saldo);
            var usuario = new ContaBancaria(NumeroConta, NomeTitular, Saldo);
            Contas.Add(usuario);
            Console.WriteLine($"Conta[{NumeroConta}] cadastrada com sucesso!");
        }

        public void RemoverConta(ContaBancaria conta)
        {
            foreach (var user in Contas)
            {
                if (user.NumeroConta == conta.NumeroConta)
                {
                    Contas.Remove(conta);
                }
                else
                {
                    //Exceção de conta ja existente para tratar la em services!
                }
            }
        }

    }
}
