using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;

namespace Final.Warehouse
{
    [DataContract]
    public class Node
    {
        public Node( int id, float x, float y )
        {
            this.Id = id;
            this.Position = new Vector2( x, y );
            this.Segments = new List<Segment>( );
        }

        [DataMember]
        public int Id { get; }

        [DataMember]
        public Vector2 Position { get; }

        public List<Segment> Segments { get; }

        public Segment Connect( int id, Node otherNode )
        {
            var segment = new Segment( id, this, otherNode );
            this.Segments.Add( segment );
            otherNode.Segments.Add( segment );

            return segment;
        }

        public override string ToString( )
        {
            return string.Format( "{0}:({1},{2})", this.Id, this.Position.X, this.Position.Y );
        }
    }
}