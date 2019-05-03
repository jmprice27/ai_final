namespace Final.Agent
{
    using Final.Agent.Interfaces;
    using Final.Common;
    using Final.Warehouse;
    
    public interface IAgent : IMoving
    {
        Segment CurrentSegment { get; }

        Node LastNode { get; }

        Route Route { get; }

        Sensor Sensor { get; }
        bool HasRoute { get; }

        void Advance( );

        void AssignDestination( Node destination );
    }
}