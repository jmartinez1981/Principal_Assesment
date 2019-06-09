using TransportManager.Domain;
using TransportManager.Services.Factory;

namespace TransportManager.Services.Strategy
{
    internal class StoreSampleMinPriorityOperation : IOperationStrategy
    {
        private readonly ILaboratory laboratory;

        public string SampleId { get; set; }

        public StoreSampleMinPriorityOperation(ILaboratory laboratory)
        {
            this.laboratory = laboratory;
        }

        public void Perform()
        {
            this.laboratory.Accept(new MinimumPriorityVisitor(), SampleId);
        }

        public bool IsValid(string operationId)
        {
            return (int)OperationType.StoreSampleNoPriority == int.Parse(operationId);
        }
    }
}
