namespace Final.Warehouse.UnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RouteTests
    {
        private readonly Map map = new Map( 3, 3 );

        [TestMethod]
        public void EndTest( )
        {
            var route = new Route( this.map.Nodes.GetRange( 0, 3 ), this.map.Segments.GetRange( 0, 2 ) );

            Assert.AreEqual( this.map.Nodes[ 2 ], route.End );
        }

        [TestMethod]
        public void LengthTest( )
        {
            var route = new Route( this.map.Nodes.GetRange( 0, 3 ), this.map.Segments.GetRange( 0, 2 ) );

            Assert.AreEqual( this.map.ColumnWidth * 2, route.Length );
        }

        [TestMethod]
        public void RouteTest( )
        {
            var route = new Route( this.map.Nodes.GetRange( 0, 3 ), this.map.Segments.GetRange( 0, 2 ) );

            CollectionAssert.AreEqual( this.map.Nodes.GetRange( 0, 3 ), route.NodeList );
            CollectionAssert.AreEqual( this.map.Segments.GetRange( 0, 2 ), route.SegmentList );

            Assert.ThrowsException<ArgumentException>( ( ) => new Route( this.map.Nodes.GetRange( 0, 3 ), this.map.Segments.GetRange( 3, 2 ) ) );
        }

        [TestMethod]
        public void StartTest( )
        {
            var route = new Route( this.map.Nodes.GetRange( 0, 3 ), this.map.Segments.GetRange( 0, 2 ) );

            Assert.AreEqual( this.map.Nodes[ 0 ], route.Start );
        }
    }
}