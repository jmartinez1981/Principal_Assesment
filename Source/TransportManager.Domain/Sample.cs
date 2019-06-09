
namespace TransportManager.Domain
{
    public class Sample : Element
    {
        public string Id { get; }
        public int Priority { get; private set; }
        public int TestPrice { get; private set; }

        public Sample(string id)
        {
            this.Id = id;
        }

        public void AssignPriority(int priority)
        {
            this.Priority = priority;
        }

        public void AssignTestPrice(int testPrice)
        {
            this.TestPrice = testPrice;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
