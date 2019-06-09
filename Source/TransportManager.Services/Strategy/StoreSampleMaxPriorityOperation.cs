using System;
using System.Collections.Generic;
using System.Text;
using TransportManager.Domain;
using TransportManager.Services.Factory;

namespace TransportManager.Services.Strategy
{
    internal class StoreSampleMaxPriorityOperation : IOperationStrategy
    {
        private readonly ILaboratory laboratory;

        public string SampleId { get; set; }

        public StoreSampleMaxPriorityOperation(ILaboratory laboratory)
        {
            this.laboratory = laboratory;
        }

        public void Perform()
        {
            this.laboratory.Accept(new MaximumPriorityVisitor(), SampleId);
        }

        public bool IsValid(string operationId)
        {
            return (int)OperationType.StoreSampleMaxPriority == int.Parse(operationId);
        }
    }
}
