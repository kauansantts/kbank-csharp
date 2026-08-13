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


        public ContaBancaria Login(int numberCont, string nameCont)//PRIMEIRA opc do primeiro menu
        {
            foreach (var conta in Contas)
            {
                if (conta.NumeroConta == numberCont && conta.NomeTitular == nameCont)
                {
                    Console.WriteLine($"Bem vindo {conta.NomeTitular}!");
                    Console.WriteLine("=============================");
                    return conta;
                }
            }
            throw new ContaInexistenteException("\"Essa conta não existe!\"");
        }
        public void CadastrarConta()//SEGUNDA opc do primeiro menu
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

        public void RemoverConta(int numberCont, string nameCont)//So consegue usar esse metodo, se ja estiver dentro da conta!
        {
            var resultbusca = BuscarConta(numberCont, nameCont);
            Console.WriteLine($"Conta[{resultbusca.NumeroConta}] removida com sucesso!");
            Contas.Remove(resultbusca);
        }



        public ContaBancaria BuscarConta(int numberCont, string nameCont)//metodo generico de busca de contas!
        {
            foreach (var user in Contas)
            {
                if (user.NumeroConta == numberCont && user.NomeTitular == nameCont)
                {
                    Console.WriteLine($"Conta encontrada: [{user.NomeTitular}]");
                    return user;
                }
            }
            throw new ContaInexistenteException("Essa conta não existe!");
        }
    }
}
