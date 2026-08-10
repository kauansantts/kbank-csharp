using System;
using System.Collections.Generic;
using System.Text;
using KBank.Exceptions;
using KBank.Utils;
using KBank.Enums;


namespace KBank.Models
{
    public class Transacoes
    {
        public DateTime DataTransacao { get; set; }
        public double Valor {  get; set; }
        public EnumTransacoes TipoTransacoes { get; set; }
    }
}
