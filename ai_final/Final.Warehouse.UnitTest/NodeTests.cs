namespace Final.Warehouse.UnitTest
{
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NodeTests
    {
        private const int id = 1;

        private const float x = 35.5f;

        private const float y = 102.7f;

        [TestMethod]
        public void ConnectTest( )
        {
            var node1 = new Node( id, x, y );
            var node2 = new Node( id * 2, x * 2, y * 2 );
            var node3 = new Node( id * 3, x * 3, y * 3 );

            var segment1 = node1.Connect( id, node2 );
            var segment2 = node2.Connect( id * 2, node3 );

            Assert.AreEqual( id, segment1.Id );
            Assert.AreEqual( id * 2, segment2.Id );

            Assert.AreEqual( Vector2.Distance( node1.Position, node2.Position ), segment1.Length );
            Assert.AreEqual( Vector2.Distance( node2.Position, node3.Position ), segment2.Length );

            Assert.AreEqual( segment1, node1.Segments[ 0 ] );
            Assert.AreEqual( segment1, node2.Segments[ 0 ] );
            Assert.AreEqual( segment2, node2.Segments[ 1 ] );
            Assert.AreEqual( segment2, node3.Segments[ 0 ] );
        }

        [TestMethod]
        public void NodeTest( )
        {
            var node = new Node( id, x, y );

            Assert.AreEqual( id, node.Id );
            Assert.AreEqual( x, node.Position.X );
            Assert.AreEqual( y, node.Position.Y );
        }
    }
}