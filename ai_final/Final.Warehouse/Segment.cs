using System;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Final.Warehouse
{
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

        public Task<bool> ContainsPosition( Vector2 position )
        {
            // TODO: calculate intercept
            throw new NotImplementedException( );
        }

        public override string ToString( )
        {
            return string.Format( "{0}:({1})<->({2})", this.Id, this.Ends.Item1.Id, this.Ends.Item2.Id );
        }
    }
}