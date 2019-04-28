namespace Final.Warehouse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Route
    {
        public Route( List<Node> nodeList, List<Segment> segmentList )
        {
            this.NodeList = nodeList;
            this.SegmentList = segmentList;

            this.CheckConnected( this.Start, 0 );
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

        // Throws exception if node not connected
        private void CheckConnected(Node node, int index)
        {
            var segment = node.Segments.FirstOrDefault( s => s.Ends.Item1 == this.NodeList[ index + 1 ] || s.Ends.Item2 == this.NodeList[ index + 1 ] );

            if (segment == null || segment != this.SegmentList[index])
            {
                throw new ArgumentException( );
            }

            var nextNode = segment.Ends.Item1 == node ? segment.Ends.Item2 : segment.Ends.Item1;

            if (nextNode == null)
            {
                throw new ArgumentException( );
            }
            else if (nextNode != this.End)
            {
                this.CheckConnected( nextNode, ++index );
            }
            else
            {
                return;
            }
        }
    }
}