namespace Final.Agent
{
    using System.Numerics;
    using Final.Common;
    using Final.Warehouse;

    public class ControlledWorker
    {
        public ControlledWorker( Vector2 position, float speed = 1.0f )
        {
            this.Position = position;
            this.Speed = speed;
        }

        public Vector2 Position { get; private set; }

        public float Speed { get; }

        public Vector2 Move( Direction direction, Map warehouse, int time = 1 )
        {
            var possiblePosition = new Vector2( this.Position.X, this.Position.Y );

            switch( direction )
            {
                case Direction.Unknown:
                    break;

                case Direction.North:
                    possiblePosition += new Vector2( 0, time * this.Speed );
                    break;

                case Direction.South:
                    possiblePosition -= new Vector2( 0, time * this.Speed );
                    break;

                case Direction.East:
                    possiblePosition += new Vector2( time * this.Speed, 0 );
                    break;

                case Direction.West:
                    possiblePosition -= new Vector2( time * this.Speed, 0 );
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