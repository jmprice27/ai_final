using System;
using System.Collections.Generic;
using System.Text;
using Final.Common;

namespace Final.Agent
{
    interface IAgent
    {
        IPosition Position { get; }

        IRoute Route { get; }
    }
}
