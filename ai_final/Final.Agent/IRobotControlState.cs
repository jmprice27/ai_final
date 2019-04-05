using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    public interface IRobotControlState
    {
        List<IPosition> RobotPositions { get; }
        List<IWaypoint> RobotDestinations { get; }
        List<ISensorReading> Sensors { get; }

        DateTime Time { get; }

        Dictionary<IPosition, double> WorkerHeatmap { get; }

        double DemandedThroughput { get; }

        double Evaluate( );
    }
}
