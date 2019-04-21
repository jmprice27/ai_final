using Final.Common;

namespace Final.Agent
{
    internal interface IAgent
    {
        IPosition Position { get; }

        IRoute Route { get; }

        IAgentAction Action { get; }
    }
}