using System.Collections.Generic;
using Final.Warehouse;

namespace Final.Agent
{
    internal interface IRoute
    {
        Node End { get; }

        IReadOnlyList<Node> NodeList { get; }

        IReadOnlyList<Segment> SegmentList { get; }

        Node Start { get; }
    }
}