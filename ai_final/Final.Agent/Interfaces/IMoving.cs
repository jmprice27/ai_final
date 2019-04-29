namespace Final.Agent.Interfaces
{
    using System.Numerics;
    using Final.Common;
    using Final.Warehouse;

    internal interface IMoving
    {
        Vector2 Position { get; }

        float Speed { get; }

        Vector2 Move( Direction direction, Map warehouse, int timeStep );
    }
}