namespace UI
{
    using System.Media;
    using System.Numerics;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Final.Agent;
    using Final.Common;

    public class ControlledWorkerVM
    {
        ControlledWorker model;

        public ControlledWorkerVM( ControlledWorker worker )
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
        }

        public int Radius { get; }

        public Brush Color { get; }

        public Shape Shape { get; }

        public Vector2 Position
        {
            get
            {
                return this.model.Position - new Vector2( this.Radius / 2, this.Radius / 2 );
            }
        }

        public void MoveWorker(Direction direction)
        {
            this.model.Move( direction );

            Canvas.SetLeft( this.Shape, this.Position.X);
            Canvas.SetTop( this.Shape, this.Position.Y);
        }
    }
}