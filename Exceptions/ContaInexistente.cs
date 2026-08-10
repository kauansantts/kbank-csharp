using System;
using System.Collections.Generic;
using System.Text;

namespace KBank.Exceptions
{
    public class ContaInexistente : Exception
    {
        public ContaInexistente() { }
        public ContaInexistente(string message) : base(message) { }
    }
}
