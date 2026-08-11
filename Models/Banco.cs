using System;
using System.Collections.Generic;
using System.Text;
using KBank.Exceptions;

namespace KBank.Models
{
    public class Banco
    {
        public  List<ContaBancaria> Contas = new List<ContaBancaria>();

        public Banco() { }


        public void Login(int numberCont, string nameCont)
        {
            foreach (var conta in Contas)
            {
                if (conta.NumeroConta == numberCont && conta.NomeTitular == nameCont)
                {
                    Console.WriteLine($"Bem vindo {conta.NomeTitular}!");
                    Console.WriteLine("=============================");
                    return;
                }
            }
            throw new ContaInexistenteException("\"Essa conta não existe!\"");
        }
        public void CadastrarConta()
        {
            Console.WriteLine("==Gerando numero de conta=========");
            var NumeroConta = new Random().Next(1000, 9999);
            foreach (var conta in Contas)
            {
                if (conta.NumeroConta == NumeroConta)
                {
                    var NumeroContaNovo = new Random().Next(1000, 9999);
                    NumeroConta = NumeroContaNovo;
                }
            }
            string NomeTitular;
            Console.WriteLine($"Número da conta: {NumeroConta}");
            Console.WriteLine("Digite o nome do titular: ");
            NomeTitular = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial: ");
            double.TryParse(Console.ReadLine(), out double Saldo);
            var usuario = new ContaBancaria(NumeroConta, NomeTitular, Saldo);
            Contas.Add(usuario);
            Console.WriteLine($"Conta[{NumeroConta}] cadastrada com sucesso!");
            Console.WriteLine("=============================");
        }

        public void RemoverConta(ContaBancaria conta)//So consegue usar esse metodo, se ja estiver dentro da conta!
        {
            if (BuscarConta(conta) == conta)
            {
                Contas.Remove(conta);
                Console.WriteLine($"Conta[{conta.NumeroConta}] removida com sucesso!");
            }
        }



        public ContaBancaria BuscarConta(ContaBancaria conta)
        {
            foreach (var user in Contas)
            {
                if (user.NumeroConta == conta.NumeroConta && user.NomeTitular == conta.NomeTitular)
                {
                    Console.WriteLine($"Conta encontrada: [{conta.NomeTitular}]");
                    return conta;
                }
            }
            throw new ContaInexistenteException("Essa conta não existe!");

        }
    }
}
