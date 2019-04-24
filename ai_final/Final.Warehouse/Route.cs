namespace Final.Warehouse
{
    using System;
    using System.Collections.Generic;

    public class Route
    {
        public Route( List<Node> nodeList, List<Segment> segmentList )
        {
            this.NodeList = nodeList;
            this.SegmentList = segmentList;
        }

        private float Cost
        {
            get
            {
                throw new NotImplementedException( );
            }
        }

        private Node End { get => this.NodeList[ this.NodeList.Count - 1 ]; }

        private float Length
        {
            get
            {
                throw new NotImplementedException( );
            }
        }

        private List<Node> NodeList { get; }

        private List<Segment> SegmentList { get; }

        private Node Start { get => this.NodeList[ 0 ]; }
    }
}