using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    public interface IReviewFile
    {
        string SchemaVersion { get; set; }

        IReview Review { get; }
    }
}
