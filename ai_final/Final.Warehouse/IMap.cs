using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Final.Common;

namespace Final.Warehouse
{
    interface IMap
    {
        [DataMember]
        IReadOnlyCollection<INode> Nodes { get; }

        [DataMember]
        IReadOnlyCollection<ISegment> Segments { get; }

        [DataMember]
        IReadOnlyCollection<IWaypoint> Waypoints { get; }

        Task Save( string fileName );

        Task Open( string fileName );

        Task Create( );

        Task<ISegment> GetSegment( IPosition position );

        Task<INode> GetNearestNode( IPosition position );
    }
}
