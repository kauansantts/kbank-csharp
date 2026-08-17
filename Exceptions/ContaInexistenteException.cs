using System;
using System.Collections.Generic;
using System.Text;

namespace KBank.Exceptions
{
    public class ContaInexistenteException : Exception
    {
        public ContaInexistenteException(string message) : base(message) { }
    }
}
