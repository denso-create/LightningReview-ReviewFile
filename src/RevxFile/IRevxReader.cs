using LightningReview.RevxFile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxFile
{
    interface IRevxReader
    {
        Review Load(string filepath);
    }
}
