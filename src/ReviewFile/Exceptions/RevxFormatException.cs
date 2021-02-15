using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Exceptions
{
    public class ReviewFileFormatException : Exception
    {
        public ReviewFileFormatException(string message = null,Exception innterException=null) : base(message, innterException) { }
    }
}
