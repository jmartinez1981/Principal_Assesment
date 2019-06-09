namespace TransportManager.Services.Factory
{
    /// <summary>
    /// Describes different operation types
    /// </summary>
    internal enum OperationType
    {
        ArriveSample = 0,

        StoreSampleNoPriority = 1,

        StoreSampleMaxPriority = 2,
        
        LeftSample = 3
    }
}
