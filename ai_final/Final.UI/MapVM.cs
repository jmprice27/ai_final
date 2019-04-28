using System.Collections.Generic;
using Final.Warehouse;

namespace UI
{
    internal class MapVM
    {
        public MapVM( Map map )
        {
            this.Map = map;
            this.AisleWidth = 10;
            this.NodeRadius = 12;
        }

        public double AisleWidth { get; }

        public Map Map { get; }

        public double NodeRadius { get; }

        public List<Node> Nodes
        {
            get
            {
                return this.Map.Nodes;
            }
        }

        public List<Segment> Segments
        {
            get
            {
                return this.Map.Segments;
            }
        }
    }
}