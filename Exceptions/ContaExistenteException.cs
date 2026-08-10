using System;
using System.Collections.Generic;
using System.Text;

namespace KBank.Exceptions
{
    public class ContaExistenteException : Exception
    {
        public ContaExistenteException(string message) : base(message) { }
        public ContaExistenteException() { }
    }
}
