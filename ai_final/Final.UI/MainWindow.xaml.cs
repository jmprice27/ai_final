namespace UI
{
    using System;
    using System.Numerics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Final.Agent;
    using Final.Common;
    using Final.Warehouse;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( )
        {
            this.InitializeComponent( );

            this.Map = new MapVM( new Map( 20, 33 ) );
            this.Controlled = new ControlledWorkerVM( new ControlledWorker( new Vector2( 1000, 420 ) ), this.Map.Map );

            this.DrawSegments( );
            this.DrawNodes( );

            this.WarehouseCanvas.Children.Add( this.Controlled.Shape );
        }

        public ControlledWorkerVM Controlled { get; set; }

        public MapVM Map { get; set; }

        private void ControlButton_Checked( object sender, RoutedEventArgs e )
        {
            var isChecked = ( sender as ToggleButton ).IsChecked;

            this.Map.IsManuallyControlled = isChecked ?? false;
        }

        private void DrawNodes( )
        {
            this.Map.Nodes.ForEach( node =>
            {
                Shape shape = new Ellipse( )
                {
                    Height = this.Map.NodeRadius,
                    Width = this.Map.NodeRadius,
                    Tag = node,
                    Fill = Brushes.Blue,
                    Opacity = 0.5,
                    ToolTip = new ToolTip( ) { Content = string.Format( "Node {0}", node.ToString( ) ) }
                };

                Canvas.SetLeft( shape, node.Position.X - this.Map.NodeRadius / 2 );
                Canvas.SetTop( shape, node.Position.Y - this.Map.NodeRadius / 2 );

                this.WarehouseCanvas.Children.Add( shape );
            } );
        }

        private void DrawSegments( )
        {
            this.Map.Segments.ForEach( segment =>
            {
                Polyline line = new Polyline( )
                {
                    ToolTip = new ToolTip( ) { Content = string.Format( "Segment {0}", segment.Id ) },
                    Stroke = Brushes.Gray,
                    Opacity = 0.5,
                    StrokeThickness = this.Map.AisleWidth
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
            if( this.Map.IsManuallyControlled )
            {
                switch( e.Key )
                {
                    case Key.Left:
                        this.Controlled.Move( Direction.West, this.Map.Map );
                        break;

                    case Key.Up:
                        this.Controlled.Move( Direction.South, this.Map.Map );
                        break;

                    case Key.Right:
                        this.Controlled.Move( Direction.East, this.Map.Map );
                        break;

                    case Key.Down:
                        this.Controlled.Move( Direction.North, this.Map.Map );
                        break;
                }
            }
        }

        private void OpenButton_Click( object sender, RoutedEventArgs e )
        {
            this.Map.Map = new Map( "" );
        }

        private void SaveButton_Click( object sender, RoutedEventArgs e )
        {
            this.Map.Map.Save( "" );
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