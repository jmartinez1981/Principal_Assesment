namespace TransportManager.Domain
{
    /// <summary>
    /// A Concrete Visitor class. 
    /// Assign min priority and sample test price.
    /// </summary>
    public class MinimumPriorityVisitor : IVisitor
    {
        private const int MinPriority = 9999;
        private const int Price = 100;

        public void Visit(Element element)
        {
            var sample = element as Sample;

            sample?.AssignPriority(MinPriority);
            sample?.AssignTestPrice(Price);
        }
    }
}
