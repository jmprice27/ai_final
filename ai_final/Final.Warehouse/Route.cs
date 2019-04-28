namespace Final.Warehouse
{
    using System.Collections.Generic;

    public class Route
    {
        public Route( List<Node> nodeList, List<Segment> segmentList )
        {
            this.NodeList = nodeList;
            this.SegmentList = segmentList;
        }

        public float Cost
        {
            get
            {
                // TODO: Needed?

                var x = 1;
                return this.Length * x;
            }
        }

        public Node End { get => this.NodeList[ this.NodeList.Count - 1 ]; }

        public float Length
        {
            get
            {
                var sum = 0.0f;
                foreach( var segment in this.SegmentList )
                {
                    sum += segment.Length;
                }

                return sum;
            }
        }

        public List<Node> NodeList { get; }

        public List<Segment> SegmentList { get; }

        public Node Start { get => this.NodeList[ 0 ]; }
    }
}