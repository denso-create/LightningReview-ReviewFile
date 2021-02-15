using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.RevxFile.Models.V10
{
    public class OutlineNode : IOutlineNode
    {
        public string GID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IOutlineNode> Children => throw new NotImplementedException();
    }
}
