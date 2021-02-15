using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxFile.Exceptions
{
    public class RevxFormatException : Exception
    {
        public RevxFormatException(string message = null,Exception innterException=null) : base(message, innterException) { }
    }
}
