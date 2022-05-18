using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public class TankkaartException : Exception
    {
        public TankkaartException()
        {
        }

        public TankkaartException(string message) : base(message)
        {
        }

        public TankkaartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
