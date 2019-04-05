using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Common
{
    interface ISensor
    {
        IReadOnlyCollection<ISensorReading> SensorHits { get; }

        SensorOrientation Orientation { get;  }
    }
}
