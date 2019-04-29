namespace Final.Agent
{
    internal interface IQAgent : IAgent
    {
        QConstants Constants { get; }

        float QValue { get; }

        float Value { get; }
    }
}