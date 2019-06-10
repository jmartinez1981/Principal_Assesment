using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace TransportManager.Domain
{
    internal class Laboratory : ILaboratory
    {
        private readonly List<Sample> samples = new List<Sample>();
        private readonly ILogger<Laboratory> logger;

        public Laboratory(ILogger<Laboratory> logger)
        {
            this.logger = logger;
        }

        public void AddSample(Sample sample)
        {
            samples.Add(sample);
            this.logger.LogInformation($"The sample with id: {sample.Id} has been added");
        }

        public void RemoveSample(string id)
        {
            var sample = samples.SingleOrDefault(x => x.Id == id);

            if (sample != null)
            {
                samples.Remove(sample);
                this.logger.LogInformation($"The sample with id: {sample.Id} has been removed");
            }
        }

        public void Accept(IVisitor visitor, string sampleId)
        {
            var sample = this.GetSample(sampleId);

            if (sample != null)
            {
                sample.Accept(visitor);
                this.logger.LogInformation($"The sample with id: {sample.Id} has priority: {sample.Priority} with a test price: {sample.TestPrice}");
            }
        }

        private Sample GetSample(string id)
        {
            return samples.SingleOrDefault(x => x.Id == id);
        }
    }
}
