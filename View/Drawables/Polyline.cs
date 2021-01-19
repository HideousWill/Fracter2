using System.Drawing;

namespace Fracter2.View.Drawables
{
    public class Polyline : DrawablePointFs
    {
        public override void Draw( Graphics graphics )
        {
            graphics.DrawLines( Pen, this.ToArray() );
        }
    }
}