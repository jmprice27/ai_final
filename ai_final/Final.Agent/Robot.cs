using System;
using System.Numerics;
using Final.Common;
using Final.Warehouse;

namespace Final.Agent
{
    internal class Robot : IQAgent
    {
        public Robot( Vector2 position, QConstants constants, float speed = 10.0f )
        {
            this.Position = position;
            this.Speed = speed;
            this.Constants = constants;

            this.Sensor = new Sensor( );
        }

        public QConstants Constants { get; }

        public Segment CurrentSegment { get; private set; }

        public Node LastNode { get; private set; }

        public Vector2 Position { get; private set; }

        // TODO< this might need to be moved elsewhere - probably as a property of nodes
        public float QValue { get; private set; }

        public Route Route { get; private set; }

        public Sensor Sensor { get; }

        public float Speed { get; }

        // TODO< this might need to be moved elsewhere - probably as a property of nodes
        public float Value { get => throw new NotImplementedException( ); }

        public Vector2 Move( Direction direction, Map warehouse, int timeStep )
        {
            throw new NotImplementedException( );
        }
    }
}