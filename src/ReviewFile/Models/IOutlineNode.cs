using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    /// <summary>
    /// アウトラインノードのインタフェース
    /// </summary>
    public interface IOutlineNode
    {
        string GID { get; set; }

        string Name { get; set; }

        IEnumerable<IOutlineNode> Children { get; }
    }
}
