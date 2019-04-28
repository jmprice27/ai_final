using Final.Common;
namespace Final.Agent
{
    using Final.Warehouse;

    internal interface IAgent
    {
        float Speed { get; }

        IPosition Position { get; }

        Route Route { get; }

        IAgentAction Action { get; }
    }
}