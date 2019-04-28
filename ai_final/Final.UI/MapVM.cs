namespace UI
{
    using System.Collections.Generic;
    using Final.Warehouse;

    public class MapVM
    {
        public MapVM( )
        {
        }

        public MapVM( Map map )
        {
            this.Map = map;
            this.AisleWidth = 10;
            this.NodeRadius = 12;
        }

        public double AisleWidth { get; }

        public bool IsManuallyControlled { get; set; }

        public Map Map { get; set; }

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