using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Warehouse;

namespace UI
{
    class MapVM
    {
        public MapVM(Map map)
        {
            this.Map = map;
            this.AisleWidth = 0.2;
            this.NodeRadius = 0.05;
        }

        public Map Map { get; }

        public double AisleWidth { get; }

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
