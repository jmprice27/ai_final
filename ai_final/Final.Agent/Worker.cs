namespace Final.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Final.Agent.Interfaces;
    using Final.Common;
    using Final.Warehouse;

    public class Worker : IWorker
    {
        public Worker( Vector2 position )
        {
            this.Position = position;
        }

        public Segment CurrentSegment { get => throw new NotImplementedException( ); }

        public Node LastNode { get => throw new NotImplementedException( ); }

        public Vector2 Position { get; }

        public Route Route { get => throw new NotImplementedException( ); }

        public Sensor Sensor { get => throw new NotImplementedException( ); }

        public float Speed { get => throw new NotImplementedException( ); }
        public bool HasRoute { get => throw new NotImplementedException( ); }

        public void Advance( )
        {
            throw new NotImplementedException( );
        }

        private Route BuildRoute( Dictionary<Node, Node> cameFrom, Node start, Node currentNode )
        {
            var nodeList = new List<Node>( );
            var segmentList = new List<Segment>( );

            nodeList.Add( currentNode );

            while( currentNode != start )
            {
                var prevNode = currentNode;
                currentNode = cameFrom[ currentNode ];
                nodeList.Add( currentNode );

                // this loop finds the segment between two nodes
                // may be useful as a function of Node?
                foreach( var seg in prevNode.Segments )
                {
                    if( seg.Ends.Item1 == currentNode || seg.Ends.Item2 == currentNode )
                    {
                        segmentList.Add( seg );
                    }
                }
            }
            return new Route( nodeList, segmentList );
        }

        private Route FindRoute( Map map, Node start, Node goal )
        {
            var explored = new List<Node>( );
            var frontier = new List<Node> { start };

            var cameFrom = new Dictionary<Node, Node>( );

            var score = new Dictionary<Node, float>( );
            score[ start ] = 0;

            var priority = new Dictionary<Node, float>( );

            priority[ start ] = Vector2.Distance( start.Position, goal.Position );

            while( frontier.Count > 0 )
            {
                var currentNode = frontier[ 0 ];
                foreach( var n in frontier )
                {
                    if( priority[ n ] < priority[ currentNode ] )
                    {
                        currentNode = n;
                    }
                }

                if( currentNode == goal )
                {
                    return this.BuildRoute( cameFrom, start, currentNode );
                }

                frontier.Remove( currentNode );
                explored.Add( currentNode );

                foreach( var s in currentNode.Segments )
                {
                    var nextNode = s.Ends.Item1;
                    if( nextNode == currentNode )
                    {
                        nextNode = s.Ends.Item2;
                    }
                    if( !explored.Contains( nextNode ) )
                    {
                        var nextScore = score[ currentNode ] + s.Length;

                        if( !frontier.Contains( nextNode ) )
                        {
                            frontier.Add( nextNode );
                        }
                        else if( nextScore < score[ nextNode ] )
                        {
                            cameFrom[ nextNode ] = currentNode;
                            score[ nextNode ] = nextScore;

                            priority[ nextNode ] = score[ nextNode ] + Vector2.Distance( nextNode.Position, goal.Position );
                        }
                    }
                }
            }

            // TODO: Remove- Added to get building ( not all code paths return a value)
            throw new NotImplementedException( );
        }

        public void AssignDestination(Node destination)
        {

        }

        public Vector2 Move( Direction direction, Map warehouse, int timeStep = 1 )
        {
            throw new NotImplementedException( );
        }

        public Route ReRoute( )
        {
            throw new NotImplementedException( );
        }
    }
}