﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public class AdresException : Exception
    {
        public AdresException()
        {
        }

        public AdresException(string message) : base(message)
        {
        }

        public AdresException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
