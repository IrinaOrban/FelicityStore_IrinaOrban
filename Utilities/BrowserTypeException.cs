using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FelicityStore_IrinaOrban.Utilities
{
    class BrowserTypeException:Exception
    {
        public BrowserTypeException()
        {
        }
        public BrowserTypeException(string message) : base("Unsupported browser type " + message)
        {

        }
        public BrowserTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected BrowserTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
