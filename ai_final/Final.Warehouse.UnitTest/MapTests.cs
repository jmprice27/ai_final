namespace Final.Warehouse.UnitTest
{
    using System.Numerics;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MapTests
    {
        private const int columns = 20;

        private const float columnWidth = 10;

        private const string fileName = "testMap.json";

        private const float rowHeight = 10;

        private const int rows = 10;

        [Ignore]
        [TestMethod]
        public async Task FileTest( )
        {
            var map = new Map( rows, columns, rowHeight, columnWidth );

            map.Save( fileName );

            var fileMap = new Map( fileName );
        }

        [TestMethod]
        public async Task GetNearestNodeTest( )
        {
            var map = new Map( 2, 2, rowHeight, columnWidth * 2 );

            Assert.AreEqual( map.Nodes[ 0 ], await map.GetNearestNode( map.Nodes[ 0 ].Position ) );
            Assert.AreEqual( map.Nodes[ 0 ], await map.GetNearestNode( map.Nodes[ 0 ].Position + new Vector2( 0, 3 ) ) );
            Assert.AreEqual( map.Nodes[ 1 ], await map.GetNearestNode( map.Nodes[ 0 ].Position + new Vector2( 0, 17 ) ) );
            Assert.AreEqual( map.Nodes[ 0 ], await map.GetNearestNode( map.Nodes[ 0 ].Position + new Vector2( 3, 0 ) ) );
            Assert.AreEqual( map.Nodes[ 2 ], await map.GetNearestNode( map.Nodes[ 0 ].Position + new Vector2( 17, 0 ) ) );
            Assert.AreEqual( map.Nodes[ 1 ], await map.GetNearestNode( map.Nodes[ 1 ].Position ) );
        }

        [TestMethod]
        public async Task GetSegmentTest( )
        {
            var map = new Map( rows, columns, rowHeight, columnWidth );

            Assert.IsNotNull( map.GetSegment( new Vector2( rowHeight, columnWidth ) ) );
            Assert.IsNotNull( map.GetSegment( new Vector2( rowHeight + 5, columnWidth ) ) );
            Assert.IsNotNull( map.GetSegment( new Vector2( rowHeight, columnWidth + 5 ) ) );

            Assert.IsNull( map.GetSegment( new Vector2( -5, -5 ) ) );
        }

        [TestMethod]
        public void MapTest( )
        {
            var map = new Map( rows, columns, rowHeight, columnWidth );

            Assert.AreEqual( rows * columns, map.Nodes.Count );
            Assert.AreEqual( 2 * rows * columns - rows - columns, map.Segments.Count );
        }
    }
}