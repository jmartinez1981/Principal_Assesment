using System.Collections.Generic;

namespace TransportManager.Crosscutting.Helpers
{
    public static class CommandLineHelper
    {
        public const string OperationKey = "operationKey";
        public const string IdSampleKey = "idSampleKey";
        
        private const string OperationArgument = "-op";
        private const string IdSampleArgument = "-id";
        
        public static IDictionary<string, string> GetKeyMappings()
        {
            return new Dictionary<string, string>
            {
                {OperationArgument, OperationKey},
                {IdSampleArgument, IdSampleKey}
            };
        }
    }
}
