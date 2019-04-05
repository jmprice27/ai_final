using System.Collections.Generic;

namespace Final.Common
{
    internal interface ISensor
    {
        SensorOrientation Orientation { get; }

        IReadOnlyCollection<ISensorReading> SensorHits { get; }
    }
}