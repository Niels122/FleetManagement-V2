using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public class RijksregisternummerException : Exception
    {
        public RijksregisternummerException()
        {
        }

        public RijksregisternummerException(string message) : base(message)
        {
        }

        public RijksregisternummerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
