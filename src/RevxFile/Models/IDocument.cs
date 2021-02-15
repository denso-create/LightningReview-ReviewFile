using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxFile.Models
{
    public interface IDocument
    {
        string GID { get; set; }
        string LID { get; set; }
        string Name { get; set; }

        //IEnumerable<IIssue> AllIssues { get; }

        IEnumerable<IOutlineNode> OutlineNodes { get; }
    }
}
