using System;
using System.Collections.Generic;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    public interface IRobotControlState
    {
        double DemandedThroughput { get; }

        List<IWaypoint> RobotDestinations { get; }

        List<IPosition> RobotPositions { get; }

        List<ISensorReading> Sensors { get; }

        DateTime Time { get; }

        Dictionary<IPosition, double> WorkerHeatmap { get; }

        double Evaluate( );
    }
}