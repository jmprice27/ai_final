using Final.Common;
namespace Final.Agent
{
    using System.Numerics;
    using Final.Agent.Interfaces;
    using Final.Warehouse;

    internal interface IAgent : IMoving
    {
        Segment CurrentSegment { get; }

        Node LastNode { get; }

        Route Route { get; }

        Sensor Sensor { get; }
    }
}