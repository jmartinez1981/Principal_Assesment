using TransportManager.Domain;
using TransportManager.Services.Factory;

namespace TransportManager.Services.Strategy
{
    internal class ArriveSampleOperation : IOperationStrategy
    {
        private readonly ILaboratory laboratory;

        public ArriveSampleOperation(ILaboratory laboratory)
        {
            this.laboratory = laboratory;
        }

        public string SampleId { get; set; }

        public void Perform()
        {
            var sample = new Sample(SampleId);

            this.laboratory.AddSample(sample);
        }

        public bool IsValid(string operationId)
        {
            return (int)OperationType.ArriveSample == int.Parse(operationId);
        }
    }
}
