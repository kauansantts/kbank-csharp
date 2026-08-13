using System;
using System.Collections.Generic;
using System.Text;
using KBank.Exceptions;
using KBank.Enums;
using System.IO;


namespace KBank.Models
{
    public class Transacoes
    {
        public DateTime DataTransacao { get; set; }
        public double Valor {  get; set; }
        public EnumTransacoes TipoTransacoes { get; set; }

        public Transacoes(DateTime dataTransacao, double valor,  EnumTransacoes tipoTransacoes)
        {
            DataTransacao = dataTransacao;
            Valor = valor;
            TipoTransacoes = tipoTransacoes;
        }
    }
}
