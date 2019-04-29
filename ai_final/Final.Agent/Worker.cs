namespace Final.Agent
{
    using System.Collections.Generic;
    using System.Numerics;
    using Final.Common;
    using Final.Warehouse;

    internal class Worker
    {
        public Route build_path(Dictionary<Node, Node> came_from, Node start, Node current_node)
        {
            var nodeList = new List<Node>();
            var segmentList = new List<Segment>();

            nodeList.Add(current_node);

            while (current_node != start)
            {
                var prev_node = current_node;
                current_node = came_from[current_node];
                nodeList.Add(current_node);

                // this loop finds the segment between two nodes
                // may be useful as a function of Node?
                foreach (var seg in prev_node.Segments)
                {
                    if( seg.Ends.Item1 == current_node || seg.Ends.Item2 == current_node )
                    {
                        segmentList.Add( seg );
                    }
                }
            }
            return new Route(nodeList, segmentList);
        }

        public Route find_path(Map m, Node start, Node goal)
        {
            var explored = new List<Node>();
            var frontier = new List<Node>();
            frontier.Add(start);

            var came_from = new Dictionary<Node, Node>();

            var score = new Dictionary<Node, float>();
            score[start] = 0;

            var priority = new Dictionary<Node, float>();
            
            priority[start] = Vector2.Distance(start.Position, goal.Position);

            while(frontier.Count > 0)
            {
                var current_node = frontier[0];
                foreach (var n in frontier)
                {
                    if( priority[ n ] < priority[ current_node ] )
                    {
                        current_node = n;
                    }
                }

                if( current_node == goal )
                {
                    return this.build_path( came_from, start, current_node );
                }

                frontier.Remove(current_node);
                explored.Add(current_node);
                
                foreach(var s in current_node.Segments)
                {
                    var next_node = s.Ends.Item1;
                    if( next_node == current_node )
                    {
                        next_node = s.Ends.Item2;
                    }
                    if (!explored.Contains(next_node))
                    {
                        var nextscore = score[current_node] + s.Length;

                        if (!frontier.Contains(next_node))
                        {
                            frontier.Add(next_node);
                        }
                        else if (nextscore < score[next_node])
                        {
                            came_from[next_node] = current_node;
                            score[next_node] = nextscore;
                            
                            priority[next_node] = score[ next_node ] + Vector2.Distance(next_node.Position, goal.Position);
                        }
                    }
                }
            }
        }
    }
}