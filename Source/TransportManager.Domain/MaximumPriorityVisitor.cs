using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManager.Domain
{
    /// <summary>
    /// A Concrete Visitor class.
    /// </summary>
    public class MaximumPriorityVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var sample = element as Sample;

            sample?.AssignPriority(1);
            sample?.AssignTestPrice(5000);
        }
    }
}
