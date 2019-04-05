using System;
using System.Collections.Generic;
using System.Text;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    interface IRoute
    {
        IReadOnlyList<INode> NodeList { get; }

        IReadOnlyList<ISegment> SegmentList { get; }

        IWaypoint End { get; }

        IWaypoint Start { get; }
    }
}
