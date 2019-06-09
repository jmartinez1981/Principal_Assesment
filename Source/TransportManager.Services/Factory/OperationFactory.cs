using System.Collections.Generic;
using System.Linq;
using TransportManager.Services.Strategy;

namespace TransportManager.Services.Factory
{
    internal class OperationFactory :IOperationFactory
    {
        private readonly IEnumerable<IOperationStrategy> strategies;

        public OperationFactory(IEnumerable<IOperationStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IOperationStrategy GetOperation(string id, string value)
        {
            var strategy = strategies.SingleOrDefault(item => item.IsValid(id));

            if (strategy != null)
            {
                strategy.SampleId = value;
            }
            return strategy;
        }
    }
}
