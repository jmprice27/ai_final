namespace UI
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Final.Warehouse;

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
            this.DrawNodes( );
        }

        public MapVM Warehouse { get; set; }

        private void ControlButton_Checked( object sender, RoutedEventArgs e )
        {
            var isChecked = ( sender as ToggleButton ).IsChecked;

            this.Warehouse.IsManuallyControlled = isChecked ?? false;
        }

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

                Canvas.SetLeft( shape, node.Position.X - this.Warehouse.NodeRadius / 2 );
                Canvas.SetTop( shape, node.Position.Y - this.Warehouse.NodeRadius / 2 );

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

        private void OnKeybaordInput( object sender, KeyEventArgs e )
        {
            if( this.Warehouse.IsManuallyControlled )
            {
                switch( e.Key )
                {
                    case Key.Left:
                        break;

                    case Key.Up:
                        break;

                    case Key.Right:
                        break;

                    case Key.Down:
                        break;
                }
            }
        }

        private void OpenButton_Click( object sender, RoutedEventArgs e )
        {
            this.Warehouse.Map = new Map( "" );
        }

        private void SaveButton_Click( object sender, RoutedEventArgs e )
        {
            this.Warehouse.Map.Save( "" );
        }

        private void StartButton_Click( object sender, RoutedEventArgs e )
        {
            throw new NotImplementedException( );
        }

        private void StopButton_Click( object sender, RoutedEventArgs e )
        {
            throw new NotImplementedException( );
        }

        private void WindowLoaded( object sender, RoutedEventArgs e )
        {
            this.KeyDown += new System.Windows.Input.KeyEventHandler( this.OnKeybaordInput );
        }
    }
}