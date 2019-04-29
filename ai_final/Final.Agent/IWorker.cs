namespace Final.Agent
{
    internal interface IWorker : IAgent
    {
        public Route build_path(Dictionary<Node, List<Node>> came_from, Node start, Node current_node)
        {
            List<Node> nodeList = new List<Node>();
            List<Segment> segmentList = new List<Segment>();

            nodeList.push(current_node);

            while (current_node != start) {
                prev_node = current_node;
                current_node = came_from[current_node];
                nodeList.push(current_node);

                // this loop finds the segment between two nodes
                // may be useful as a function of Node?
                foreach (var seg in prev_node.Segments) {
                    if (seg.Ends[0] == current_node || seg.Ends[1] == current_node)
                        segmentList.push(seg);
                }
            }
            return Route(nodeList, segmentList);
        }

        public Route find_path(Map m, Node start, Node goal)
        {
            var explored = new List<Node>();
            var frontier = new List<Node>();
            frontier.push(start);

            var came_from = new Dictionary<Node, List<Node> >();

            var score = new Dictionary<Node, int>();
            score[start] = 0;

            var priority = new Dictionary<Node, int>();

            // Map.getDistance is my stand-in for how to determine score; may be unneeded
            priority[start] = m.getDistance(start, goal);

            while(frontier.Count > 0) {
                var current_node = frontier[0];
                foreach (Node n in frontier) {
                    if (priority[n] < priority[current_node])
                        current_node = n;
                }

                if (current_node == goal)
                    return build_path(came_from, start, current_node);

                frontier.Remove(current_node);
                explored.push(current_node);
                
                foreach(Segment s in current_node.Segments) {
                    next_node = s.Ends[0];
                    if(next_node == current_node)
                        next_node = s.Ends[1];
                    if (!explored.Contains(next_node)) {
                        nextscore = score[current_node] + s.Length();

                        if (!frontier.Contains(next_node)) {
                            frontier.push(next_node);
                        } else if (nextscore < score[next_node]) {
                            came_from[next_node] = current_node;
                            score[next_node] = nextscore;
                            
                            // Map.getDistance gets used again here
                            priority[next_node] = score[next_score] + m.getDistance(next_node, goal);
                        }
                    }
                }
            }
        }
    }
}