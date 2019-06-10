namespace TransportManager.Domain
{
    /// <summary>
    /// The Visitor interface, which declares a Visit operation for each ConcreteVisitor to implement.
    /// </summary>
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
