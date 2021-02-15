using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    public interface IReview
    {
        string GID { get; set; }

        string Name { get; set; }
        string Goal { get; set; }

        string Domain { get; set; }

        string Place { get; set; }

        string PlannedDate { get; set; }

        string ActualDate { get; set; }

        string PlannedTime { get; set; }

        string ActualTime { get; set; }

        string Unit { get; set; }
        string PlannedScale { get; set; }

        string FilePath { get; set; }

        IEnumerable<IIssue> Issues { get; }

        IEnumerable<IDocument> Documents { get; }

        string CreatedBy { get; }
        
        DateTime CreatedDateTime { get; }

        string LastUpdatedBy { get; set; }

        DateTime LastUpdatedDateTime { get; }

    }
}
