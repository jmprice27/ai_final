using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Final.Common;

namespace Final.Warehouse
{
    public interface ISegment : INamed
    {
        [DataMember]
        Tuple<INode, INode> Ends { get; }

        float Length { get; }

        Task<bool> ContainsPosition( IPosition position );
    }
}
