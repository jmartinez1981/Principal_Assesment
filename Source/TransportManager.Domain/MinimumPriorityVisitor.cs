namespace TransportManager.Domain
{
    /// <summary>
    /// A Concrete Visitor class.
    /// </summary>
    public class MinimumPriorityVisitor : IVisitor
    {
        private const int MaxPriority = 9999;
        private const int Price = 100;

        public void Visit(Element element)
        {
            var sample = element as Sample;

            sample?.AssignPriority(MaxPriority);
            sample?.AssignTestPrice(Price);
        }
    }
}
