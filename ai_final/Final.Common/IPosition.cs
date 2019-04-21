using System.Numerics;

namespace Final.Common
{
    public interface IPosition
    {
        Vector2 CoordinatesMeters { get; }

        Direction Direction { get; }
    }
}