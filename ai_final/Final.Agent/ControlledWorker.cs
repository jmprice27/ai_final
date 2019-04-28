namespace Final.Agent
{
    using System.Numerics;
    using Final.Common;

    public class ControlledWorker
    {
        public ControlledWorker( Vector2 position, float speed = 1.0f)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public Vector2 Position { get; private set; }

        public float Speed { get; }

        public Vector2 Move( Direction direction, int time = 1 )
        {
            switch( direction )
            {
                case Direction.Unknown:
                    break;

                case Direction.North:
                    this.Position += new Vector2( 0, time * this.Speed );
                    break;

                case Direction.South:
                    this.Position -= new Vector2( 0, time * this.Speed );
                    break;

                case Direction.East:
                    this.Position += new Vector2( time * this.Speed, 0 );
                    break;

                case Direction.West:
                    this.Position -= new Vector2( time * this.Speed, 0 );
                    break;

                case Direction.Stop:
                    break;
            }

            return this.Position;
        }
    }
}