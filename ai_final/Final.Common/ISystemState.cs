using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Final.Common
{
    public interface ISystemState
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
