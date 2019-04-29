namespace Final.Agent.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using Final.Common;
    using Final.Warehouse;

    interface IMoving
    {
        float Speed { get; }

        Vector2 Position { get; }

        Vector2 Move( Direction direction, Map warehouse, int timeStep );
    }
}
