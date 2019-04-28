namespace Final.Warehouse
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    [DataContract]
    public class Map
    {
        private readonly float largestSegment = 0.0f;

        private readonly int searchDimensions = 0;

        public Map( int rows, int columns, float rowHeight = 100, float columnWidth = 30 )
        {
            this.RowHeight = rowHeight;
            this.ColumnWidth = columnWidth;

            this.Nodes = new List<Node>( );
            this.Segments = new List<Segment>( );

            var nodeId = 0;
            var segmentId = 0;

            var rowNodes = new List<Node>( );

            foreach( var row in Enumerable.Range( 0, rows ) )
            {
                Node lastNode = null;
                foreach( var column in Enumerable.Range( 0, columns ) )
                {
                    var newNode = new Node( nodeId++, row * this.RowHeight, column * this.ColumnWidth );

                    if( lastNode != null )
                    {
                        var newSegment = newNode.Connect( segmentId++, lastNode );

                        if( newSegment.Length > this.largestSegment )
                        {
                            this.largestSegment = newSegment.Length;
                        }

                        this.Segments.Add( newSegment );
                    }

                    this.Nodes.Add( newNode );
                    lastNode = newNode;
                }

                if( row > 0 )
                {
                    for( var i = ( row - 1 ) * columns; i < row * columns; i++ )
                    {
                        var newSegment = this.Nodes[ i ].Connect( segmentId++, this.Nodes[ i + columns ] );

                        if( newSegment.Length > this.largestSegment )
                        {
                            this.largestSegment = newSegment.Length;
                        }

                        this.Segments.Add( newSegment );
                    }
                }
            }

            this.searchDimensions = ( 2 * ( ( int ) this.largestSegment + 1 ) );
        }

        public Map( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }

        public float ColumnWidth { get; }

        [DataMember]
        public List<Node> Nodes { get; }

        public float RowHeight { get; }

        [DataMember]
        public List<Segment> Segments { get; }

        public async Task<Route> FindShortestRoute( Node start, Node end )
        {
            throw new NotImplementedException( );
        }

        public async Task<Node> GetNearestNode( Vector2 position )
        {
            var bottomBound = new Vector2( position.X - this.largestSegment, position.Y - this.largestSegment );

            // Loose w/ int/float here, but just narrowing things down
            var rect = new Rectangle( ( int ) bottomBound.X, ( int ) bottomBound.Y, this.searchDimensions, this.searchDimensions );
            var closest = this.Nodes.Where( n => rect.Contains( ( int ) n.Position.X, ( int ) n.Position.Y ) );

            var distance = float.PositiveInfinity;
            Node nearestNode = null;

            foreach( var node in closest )
            {
                var nodeDistance = Vector2.Distance( position, node.Position );

                if( nodeDistance < distance )
                {
                    distance = nodeDistance;
                    nearestNode = node;
                }
            }

            return nearestNode;
        }

        //public async Task<Node> GetNearestNode( Vector2 position )
        //{
        //    var containingSegment = await this.GetSegment( position );

        //    var distance1 = Vector2.Distance( position, containingSegment.Ends.Item1.Position );
        //    var distance2 = Vector2.Distance( position, containingSegment.Ends.Item2.Position );

        //    return distance1 < distance2 ? containingSegment.Ends.Item1 : containingSegment.Ends.Item2;
        //}

        public Node GetNearestNode( Node node )
        {
            var shortestSegment = node.Segments.Aggregate( ( s1, s2 ) => s1.Length < s2.Length ? s1 : s2 );

            return shortestSegment.Ends.Item1 == node ? shortestSegment.Ends.Item2 : shortestSegment.Ends.Item1;
        }

        public Segment GetSegment( Vector2 position )
        {
            return this.Segments.FirstOrDefault( s => s.ContainsPosition( position ) );
        }

        public bool IsLegalPosition( Vector2 position )
        {
            bool legal = false;

            try
            {
                legal = this.GetSegment( position ) != null;
            }
            catch
            {
                legal = false;
            }

            return legal;
        }

        public void Save( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }

        private void Open( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }
    }
}