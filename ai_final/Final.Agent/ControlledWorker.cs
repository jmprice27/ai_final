namespace Final.Agent
{
    using System.Numerics;
    using Final.Agent.Interfaces;
    using Final.Common;
    using Final.Warehouse;

    public class ControlledWorker : IMoving
    {
        public ControlledWorker( Vector2 position, Map map, float speed = 10.0f )
        {
            this.Position = position;
            this.Speed = speed;
            this.CurrentSegment = map.FindSegment( this.Position );

            this.LastNode = map.FindNearestNode( this.CurrentSegment, this.Position );
        }

        public Segment CurrentSegment { get; private set; }

        public Node LastNode { get; private set; }

        public Vector2 Position { get; private set; }

        public float Speed { get; }

        public Vector2 Move( Direction direction, Map warehouse, int timeStep = 1 )
        {
            var possiblePosition = new Vector2( this.Position.X, this.Position.Y );

            switch( direction )
            {
                case Direction.Unknown:
                    break;

                case Direction.North:
                    possiblePosition += new Vector2( 0, timeStep * this.Speed );
                    break;

                case Direction.South:
                    possiblePosition -= new Vector2( 0, timeStep * this.Speed );
                    break;

                case Direction.East:
                    possiblePosition += new Vector2( timeStep * this.Speed, 0 );
                    break;

                case Direction.West:
                    possiblePosition -= new Vector2( timeStep * this.Speed, 0 );
                    break;

                case Direction.Stop:
                    break;
            }

            if( warehouse.IsLegalPosition( possiblePosition ) )
            {
                this.Position = possiblePosition;
            }

            return this.Position;
        }
    }
}