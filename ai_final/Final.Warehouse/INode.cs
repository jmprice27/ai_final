using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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
