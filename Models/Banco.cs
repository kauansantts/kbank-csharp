using System;
using System.Collections.Generic;
using System.Text;
using KBank.Exceptions;

namespace KBank.Models
{
    public class Banco
    {
        public List<ContaBancaria> Contas = new List<ContaBancaria>();


        public void CadastrarConta()
        {
            Console.WriteLine("==Gerando numero de conta=========");
            var NumeroConta = new Random().Next(1000, 9999);
            foreach (var conta in Contas)
            {
                if (conta.NumeroConta == NumeroConta)
                {
                    throw new ContaExistenteException("Numero de conta ja existente!");// exceção de conta ja existente para tratar la em services!
                }
                else
                {
                    break;
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
                    throw new ContaInexistente("Essa conta não existe!");
                }
            }
        }
    }
}
