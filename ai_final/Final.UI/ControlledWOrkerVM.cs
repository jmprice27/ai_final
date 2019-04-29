namespace UI
{
    using System.Numerics;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Final.Agent;
    using Final.Common;
    using Final.Warehouse;

    public class ControlledWorkerVM
    {
        private readonly ControlledWorker model;

        public ControlledWorkerVM( ControlledWorker worker, Map warehouse )
        {
            this.model = worker;
            this.Radius = 5;
            this.Color = Brushes.Orange;

            this.Shape = new Ellipse( )
            {
                Height = this.Radius,
                Width = this.Radius,
                Tag = this,
                Fill = this.Color,
                Opacity = 1,
                ToolTip = new ToolTip( ) { Content = "Controlled Worker" }
            };

            this.Move( Direction.Stop, warehouse );
        }

        public Brush Color { get; }

        public Vector2 Position
        {
            get
            {
                return this.model.Position - new Vector2( this.Radius / 2, this.Radius / 2 );
            }
        }

        public int Radius { get; }

        public Shape Shape { get; }

        public void Move( Direction direction, Map warehouse )
        {
            this.model.Move( direction, warehouse );

            Canvas.SetLeft( this.Shape, this.Position.X );
            Canvas.SetTop( this.Shape, this.Position.Y );
        }
    }
}