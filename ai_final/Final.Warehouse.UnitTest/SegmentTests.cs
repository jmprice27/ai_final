namespace Final.Warehouse.UnitTest
{
    using System.Numerics;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SegmentTests
    {
        private const int id = 1;

        private const float x = 10;

        private const float y = 10;

        [TestMethod]
        public async Task ContainsPositionTest( )
        {
            var node1 = new Node( id, x, y );
            var node2 = new Node( id * 2, x * 2, y * 2 );

            var segment = new Segment( id, node1, node2 );

            Assert.IsTrue( segment.ContainsPosition( node1.Position ) );
            Assert.IsTrue( segment.ContainsPosition( node2.Position ) );

            Assert.IsFalse( segment.ContainsPosition( new Vector2( 17.0f, 12.0f ) ) );
            Assert.IsFalse( segment.ContainsPosition( new Vector2( 5.0f, 5.0f ) ) );
            Assert.IsFalse( segment.ContainsPosition( new Vector2( 25.0f, 25.0f ) ) );

            Assert.IsTrue( segment.ContainsPosition( new Vector2( 15.0f, 15.0f ) ) );
        }

        [TestMethod]
        public void SegmentTest( )
        {
            var node1 = new Node( id, x, y );
            var node2 = new Node( id * 2, x * 2, y * 2 );

            var segment = new Segment( id, node1, node2 );

            Assert.AreEqual( id, segment.Id );

            Assert.AreEqual( node1, segment.Ends.Item1 );
            Assert.AreEqual( node2, segment.Ends.Item2 );

            Assert.AreEqual( Vector2.Distance( node1.Position, node2.Position ), segment.Length );
        }
    }
}