using LightningReview.RevxReader.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxReader
{
    interface IRevxReader
    {
        Review Load(string filepath);
    }
}
