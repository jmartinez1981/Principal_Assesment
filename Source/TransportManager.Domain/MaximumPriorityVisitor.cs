namespace TransportManager.Domain
{
    /// <summary>
    /// A Concrete Visitor class. 
    /// Assign max priority and sample test price.
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
