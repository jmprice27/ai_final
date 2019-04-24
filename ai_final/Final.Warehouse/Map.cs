using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Final.Common;

namespace Final.Warehouse
{
    [DataContract]
    public class Map
    {
        public Map( int rows, int columns, float rowHeight = 100, float columnWidth = 30 )
        {
            this.Nodes = new List<Node>( );
            this.Segments = new List<Segment>( );

            int nodeId = 0;
            int segmentId = 0;

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

        [DataMember]
        public List<Node> Nodes { get; }

        [DataMember]
        public List<Segment> Segments { get; }

        public Task<Node> GetNearestNode( Vector2 position )
        {
            throw new NotImplementedException( );
        }

        public Task<Segment> GetSegment( IPosition position )
        {
            throw new NotImplementedException( );
        }

        public Task Open( string fileName )
        {
            throw new NotImplementedException( );
        }

        public Task Save( string fileName )
        {
            throw new NotImplementedException( );
        }
    }
}