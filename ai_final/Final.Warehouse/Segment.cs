namespace Final.Warehouse
{
    using System;
    using System.Numerics;
    using System.Runtime.Serialization;

    [DataContract]
    public class Segment
    {
        public Segment( int id, Node first, Node second )
        {
            this.Id = id;
            this.Ends = new Tuple<Node, Node>( first, second );
        }

        [DataMember]
        public Tuple<Node, Node> Ends { get; }

        [DataMember]
        public int Id { get; }

        public float Length
        {
            get
            {
                return Vector2.Distance( this.Ends.Item1.Position, this.Ends.Item2.Position );
            }
        }

        public bool ContainsPosition( Vector2 position )
        {
            var pointA = this.Ends.Item1.Position;
            var pointB = this.Ends.Item2.Position;

            return Math.Abs( Vector2.Distance( pointA, position ) + Vector2.Distance( pointB, position ) - this.Length ) < float.Epsilon;
        }

        public Node FindNearestNode( Vector2 position )
        {
            return Vector2.Distance( this.Ends.Item1.Position, position ) < Vector2.Distance( this.Ends.Item2.Position, position ) ? this.Ends.Item1 : this.Ends.Item2;
        }

        public override string ToString( )
        {
            return string.Format( "{0}:({1})<->({2})", this.Id, this.Ends.Item1.Id, this.Ends.Item2.Id );
        }
    }
}