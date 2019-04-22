using System;
using System.Collections.Generic;
using System.Numerics;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    public interface IRobotControlState
    {
        double DemandedThroughput { get; }

        List<Node> RobotDestinations { get; }

        List<Vector2> RobotPositions { get; }

        List<SensorReading> Sensors { get; }

        DateTime Time { get; }

        Dictionary<Vector2, double> WorkerBeliefs { get; }

        double Evaluate( );
    }
}