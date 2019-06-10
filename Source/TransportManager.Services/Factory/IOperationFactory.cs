using TransportManager.Services.Strategy;

namespace TransportManager.Services.Factory
{
    public interface IOperationFactory
    {
        IOperationStrategy GetOperation(string id, string value);
    }
}
