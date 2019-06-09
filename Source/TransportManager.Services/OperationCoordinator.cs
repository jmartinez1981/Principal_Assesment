using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TransportManager.Crosscutting.Helpers;
using TransportManager.Services.Factory;

namespace TransportManager.Services
{
    internal class OperationCoordinator : IOperationCoordinator
    {
        private readonly IConfiguration configuration;
        private readonly IOperationFactory operationFactory;

        public OperationCoordinator(
            IOperationFactory operationFactory, 
            IConfiguration configuration)
        {
            this.configuration = configuration;
            this.operationFactory = operationFactory;
        }

        public void Execute()
        {
            var operationsValue = this.configuration.GetValue<string>(CommandLineHelper.OperationKey);
            var idSampleValue = this.configuration.GetValue<string>(CommandLineHelper.IdSampleKey);

            if (operationsValue != null)
            {
                foreach (var operationValue in operationsValue.Split(","))
                {
                    var operation = this.operationFactory.GetOperation(operationValue, idSampleValue);

                    operation.Perform();
                }
            }
        }
    }
}
