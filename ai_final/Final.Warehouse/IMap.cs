using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Final.Common;

namespace Final.Warehouse
{
    internal interface IMap
    {
        [DataMember]
        IReadOnlyCollection<INode> Nodes { get; }

        [DataMember]
        IReadOnlyCollection<ISegment> Segments { get; }

        [DataMember]
        IReadOnlyCollection<IWaypoint> Waypoints { get; }

        Task Create( );

        Task<INode> GetNearestNode( IPosition position );

        Task<ISegment> GetSegment( IPosition position );

        Task Open( string fileName );

        Task Save( string fileName );
    }
}