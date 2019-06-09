
namespace TransportManager.Domain
{
    public interface ILaboratory
    {
        void AddSample(Sample sample);
        void RemoveSample(string id);
        void Accept(IVisitor visitor, string sampleId);
    }
}
