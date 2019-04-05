using System.Collections.Generic;
using System.Runtime.Serialization;
using Final.Common;

namespace Final.Warehouse
{
    public interface INode : INamed
    {
        [DataMember]
        IPosition Position { get; }

        [DataMember]
        IReadOnlyCollection<ISegment> Segments { get; }
    }
}