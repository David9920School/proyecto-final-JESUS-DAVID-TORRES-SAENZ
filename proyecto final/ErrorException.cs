using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final
{
    [Serializable]
    internal class ErrorException : Exception
    {
        public ErrorException() : base()
        { }

        public ErrorException(string message) : base(message)
        { }

        public ErrorException(string message, Exception innerException) 
            : base(message, innerException)
        { }

        public ErrorException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }


    }
}
