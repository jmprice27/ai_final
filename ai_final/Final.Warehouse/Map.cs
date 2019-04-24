namespace Final.Warehouse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    [DataContract]
    public class Map
    {
        public Map( int rows, int columns, float rowHeight = 100, float columnWidth = 30 )
        {
            this.Nodes = new List<Node>( );
            this.Segments = new List<Segment>( );

            var nodeId = 0;
            var segmentId = 0;

            var rowNodes = new List<Node>( );

            foreach( var row in Enumerable.Range( 0, rows ) )
            {
                foreach( var column in Enumerable.Range( 0, columns ) )
                {
                    this.Nodes.Add( new Node( nodeId++, row * rowHeight, column * columnWidth ) );
                }

                if( row > 0 )
                {
                    for( var i = ( row - 1 ) * columns; i < row * columns; i++ )
                    {
                        this.Segments.Add( this.Nodes[ i ].Connect( segmentId++, this.Nodes[ i + columns ] ) );
                    }
                }
            }
        }

        public Map( string fileName )
        {
            throw new NotImplementedException( );
        }

        [DataMember]
        public List<Node> Nodes { get; }

        [DataMember]
        public List<Segment> Segments { get; }

        public async Task<Node> GetNearestNode( Vector2 position )
        {
            throw new NotImplementedException( );
        }

        public async Task<Segment> GetSegment( Vector2 position )
        {
            throw new NotImplementedException( );
        }

        public async Task Save( string fileName )
        {
            throw new NotImplementedException( );
        }

        private async Task Open( string fileName )
        {
            throw new NotImplementedException( );
        }
    }
}