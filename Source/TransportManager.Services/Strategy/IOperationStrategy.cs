
using System.Security.Cryptography.X509Certificates;

namespace TransportManager.Services.Strategy
{
    public interface IOperationStrategy
    {
        string SampleId { get; set; }

        void Perform();

        bool IsValid(string operationId);
    }
}
