using System;
using System.Collections.Generic;
using System.Text;
using KBank.Exceptions;
using System.IO;
using System.Linq;
using KBank.Enums;
using System.Threading;

namespace KBank.Models
{
    public class Banco
    {
        public  List<ContaBancaria> Contas = new List<ContaBancaria>(); //lista de contas na ram

        public Banco()
        {
            CarregarContasDoDisco();
        }


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
            Thread.Sleep(1500);
            var NumeroConta = new Random().Next(1000, 9999);
            while (Contas.Any(conta => conta.NumeroConta == NumeroConta))
            {
                var NumeroContaNovo = new Random().Next(1000, 9999);
                NumeroConta = NumeroContaNovo;
            }

            string NomeTitular;
            Console.WriteLine($"Número da conta: {NumeroConta}");
            Console.WriteLine("Digite o nome do titular: ");
            NomeTitular = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial: ");
            double.TryParse(Console.ReadLine(), out double Saldo);
            var usuario = new ContaBancaria(NumeroConta, NomeTitular, Saldo);
            Contas.Add(usuario);//ADD A CONTA NA LISTA LOCAL

            //ADD A CONTA NO ARQUIVO
            string[] dados = {NumeroConta.ToString(), NomeTitular, Saldo.ToString()};
            var path = @$"C:\Users\kauan\Documents\DEV\C#\KBank\Contas\conta_{NumeroConta}.txt";
            if (!File.Exists(path))
            {
                File.WriteAllLines(path, dados);
            }


            Console.WriteLine($"Conta[{NumeroConta}] cadastrada com sucesso!");
            Console.WriteLine("=============================");
        }

        public void RemoverConta(int numberCont, string nameCont)//So consegue usar esse metodo, se ja estiver dentro da conta!
        {
            //REMOVE A CONTA NA LISTA LOCAL
            var resultbusca = BuscarConta(numberCont, nameCont);
            Console.WriteLine($"Conta[{resultbusca.NumeroConta}] removida com sucesso!");
            Contas.Remove(resultbusca);
            Console.WriteLine("=============================");

            //REMOVE A CONTA NO ARQUIVO
            var path = @$"C:\Users\kauan\Documents\DEV\C#\KBank\Contas\conta_{resultbusca.NumeroConta}.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
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
        
        public void CarregarContasDoDisco()//Carregando as contas para a lista de contas na RAM (disco >> ram)
        {
            var diretorio = @"C:\Users\kauan\Documents\DEV\C#\KBank\Contas";
            var arquivos = Directory.GetFiles(diretorio);

            foreach (var arquivo in arquivos)//montando a lista na ram (gambiarra rsrs)
            {
                string[] linhas = File.ReadAllLines(arquivo);//um array de todas as linhas dos arquivos
                int linhazero;
                int.TryParse(linhas[0], out linhazero);
                double linhadois;
                double.TryParse(linhas[2], out linhadois);
                var usuario = new ContaBancaria(linhazero, linhas[1], linhadois);

                if (linhas.Length > 3)
                {
                    for (int i = 3; i < linhas.Length; i++)
                    {
                        var partes = linhas[i].Split(';');
                        var partezero = Enum.Parse<EnumTransacoes>(partes[0]);
                        var parteum = double.Parse(partes[1]);
                        var partedois = DateTime.Parse(partes[2]);
                        var transacao = new Transacoes(partedois, parteum, partezero);
                        usuario.Transacoes.Add(transacao);
                    }
                }

                Contas.Add(usuario);
            }
        }
    }
}
