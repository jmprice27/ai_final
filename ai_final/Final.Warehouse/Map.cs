﻿namespace Final.Warehouse
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Final.Common;

    [DataContract]
    public class Map
    {
        private readonly float largestSegment = 0.0f;

        private readonly int searchDimensions = 0;

        public Map( int rows, int columns, float rowHeight = 100, float columnWidth = 30 )
        {
            this.RowHeight = rowHeight;
            this.ColumnWidth = columnWidth;

            this.Nodes = new List<Node>( );
            this.Segments = new List<Segment>( );

            var nodeId = 0;
            var segmentId = 0;

            var rowNodes = new List<Node>( );

            foreach( var row in Enumerable.Range( 0, rows ) )
            {
                Node lastNode = null;
                foreach( var column in Enumerable.Range( 0, columns ) )
                {
                    var newNode = new Node( nodeId++, row * this.RowHeight, column * this.ColumnWidth );

                    if( lastNode != null )
                    {
                        var newSegment = newNode.Connect( segmentId++, lastNode );

                        if( newSegment.Length > this.largestSegment )
                        {
                            this.largestSegment = newSegment.Length;
                        }

                        this.Segments.Add( newSegment );
                    }

                    this.Nodes.Add( newNode );
                    lastNode = newNode;
                }

                if( row > 0 )
                {
                    for( var i = ( row - 1 ) * columns; i < row * columns; i++ )
                    {
                        var newSegment = this.Nodes[ i ].Connect( segmentId++, this.Nodes[ i + columns ] );

                        if( newSegment.Length > this.largestSegment )
                        {
                            this.largestSegment = newSegment.Length;
                        }

                        this.Segments.Add( newSegment );
                    }
                }
            }

            this.searchDimensions = ( 2 * ( ( int ) this.largestSegment + 1 ) );
        }

        public Map( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }

        public float ColumnWidth { get; }

        [DataMember]
        public List<Node> Nodes { get; }

        public float RowHeight { get; }

        [DataMember]
        public List<Segment> Segments { get; }

        public async Task<Node> FindNearestNode( Vector2 position )
        {
            var bottomBound = new Vector2( position.X - this.largestSegment, position.Y - this.largestSegment );

            // Loose w/ int/float here, but just narrowing things down
            var rect = new Rectangle( ( int ) bottomBound.X, ( int ) bottomBound.Y, this.searchDimensions, this.searchDimensions );
            var closest = this.Nodes.Where( n => rect.Contains( ( int ) n.Position.X, ( int ) n.Position.Y ) );

            var distance = float.PositiveInfinity;
            Node nearestNode = null;

            foreach( var node in closest )
            {
                var nodeDistance = Vector2.Distance( position, node.Position );

                if( nodeDistance < distance )
                {
                    distance = nodeDistance;
                    nearestNode = node;
                }
            }

            return nearestNode;
        }

        public Node FindNearestNode( Node node )
        {
            var shortestSegment = node.Segments.Aggregate( ( s1, s2 ) => s1.Length < s2.Length ? s1 : s2 );

            return shortestSegment.Ends.Item1 == node ? shortestSegment.Ends.Item2 : shortestSegment.Ends.Item1;
        }

        public Node FindNearestNode( Segment segment, Vector2 position )
        {
            return segment.FindNearestNode( position );
        }

        public List<Direction> FindPossibleActions( Vector2 position )
        {
            var directions = new List<Direction>( );

            var segment = this.FindSegment( position );

            if (segment != null)
            {
                directions.Add( Direction.Stop );

                directions.Add( this.DetermineDirection( position, segment.Ends.Item1.Position) );
                directions.Add( this.DetermineDirection( position, segment.Ends.Item2.Position ) );
            }

            return directions;
        }

        public List<Direction> FindPossibleActions( Node node )
        {
            var directions = new List<Direction>( );

            foreach(var segment in node.Segments)
            {
                directions.Add( this.DetermineDirection( node.Position, segment.GetOtherEnd( node ).Position ) );
            }

            directions.Add( Direction.Stop );

            return directions;
        }

        public List<Direction> FindPossibleActions( Segment segment )
        {
            throw new NotImplementedException( );
        }

        public Node FindNode (int id)
        {
            return this.Nodes.FirstOrDefault( n => n.Id == id );
        }

        public Segment FindSegment( Vector2 position )
        {
            return this.Segments.FirstOrDefault( s => s.ContainsPosition( position ) );
        }

        public async Task<Route> FindShortestRoute( Node start, Node end )
        {
            throw new NotImplementedException( );
        }

        public bool IsLegalPosition( Vector2 position )
        {
            bool legal = false;

            try
            {
                legal = this.FindSegment( position ) != null;
            }
            catch
            {
                legal = false;
            }

            return legal;
        }

        public void Save( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }

        private void Open( string fileName )
        {
            // TODO: Needed?
            throw new NotImplementedException( );
        }

        private Direction DetermineDirection(Vector2 currentposition, Vector2 otherPosition)
        {
            if( otherPosition.Y > currentposition.Y)
            {
                return Direction.North;
            }
            else if (otherPosition.Y < currentposition.Y)
            {
                return Direction.South;
            }
            else if (otherPosition.X > currentposition.X)
            {
                return Direction.East;
            }
            else if (otherPosition.X < currentposition.X)
            {
                return Direction.West;
            }
            else
            {
                return Direction.Stop;
            }
        }
    }
}