using System.Collections.Generic;
using Final.Warehouse;

namespace Final.Agent
{
    internal interface IRoute
    {
        IWaypoint End { get; }

        IReadOnlyList<INode> NodeList { get; }

        IReadOnlyList<ISegment> SegmentList { get; }

        IWaypoint Start { get; }
    }
}