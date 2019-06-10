using TransportManager.Domain;
using TransportManager.Services.Factory;

namespace TransportManager.Services.Strategy
{
    internal class LeftSampleOperation : IOperationStrategy
    {
        private readonly ILaboratory laboratory;

        public string SampleId { get; set; }

        public LeftSampleOperation(ILaboratory laboratory)
        {
            this.laboratory = laboratory;
        }

        public void Perform()
        {
            this.laboratory.RemoveSample(SampleId);
        }

        public bool IsValid(string operationId)
        {
            return (int)OperationType.LeftSample == int.Parse(operationId);
        }
    }
}
