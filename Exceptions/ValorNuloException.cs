using System;
using System.Collections.Generic;
using System.Text;

namespace KBank.Exceptions
{
    public class ValorNuloException : Exception
    {
        public ValorNuloException(string message) : base(message) { }
    }
}
