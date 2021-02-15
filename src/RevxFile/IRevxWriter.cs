using LightningReview.RevxFile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxFile
{
    public interface IRevxWriter
    {
        void Write(string filePath, IReview review);
       
    }
}
