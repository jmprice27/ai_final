using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Final.Warehouse;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            this.InitializeComponent( );
            this.Warehouse = new MapVM( new Map( 20, 33 ) );

            this.DrawSegments( );

            //this.DrawNodes( );
        }

        private MapVM Warehouse { get; }

        private void DrawNodes( )
        {
            this.Warehouse.Nodes.ForEach( node =>
            {
                Shape shape = new Ellipse( )
                {
                    Height = this.Warehouse.NodeRadius,
                    Width = this.Warehouse.NodeRadius,
                    Tag = node,
                    Fill = Brushes.Blue,
                    Opacity = 0.5,
                    ToolTip = new ToolTip( ) { Content = string.Format( "Node {0}", node.Id ) }
                };

                this.WarehouseCanvas.Children.Add( shape );
            } );
        }

        private void DrawSegments( )
        {
            this.Warehouse.Segments.ForEach( segment =>
            {
                Polyline line = new Polyline( )
                {
                    ToolTip = new ToolTip( ) { Content = string.Format( "Segment {0}", segment.Id ) },
                    Stroke = Brushes.Gray,
                    Opacity = 0.5,
                    StrokeThickness = this.Warehouse.AisleWidth
                };

                var position = segment.Ends.Item1.Position;
                line.Points.Add( new Point( position.X, position.Y ) );
                position = segment.Ends.Item2.Position;
                line.Points.Add( new Point( position.X, position.Y ) );

                this.WarehouseCanvas.Children.Add( line );
            } );
        }

        private void WindowLoaded( object sender, RoutedEventArgs e )
        {
        }
    }
}