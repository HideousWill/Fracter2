using System.Drawing;

namespace Fracter2.View.Drawables
{
	public class Markers : DrawablePointFs
	{
		//----------------------------------------------------------------------
		public Markers()
		{
			Pen = new Pen( Color.Red );
		}

		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			foreach( var marker in this )
			{
				Draw( graphics, marker );
			}
		}

		SizeF Offset1 { get; } = new SizeF(  1f, 1f );
		SizeF Offset2 { get; } = new SizeF( -1f, 1f );

		//----------------------------------------------------------------------
		void Draw( Graphics graphics, PointF marker )
		{
			Draw( graphics, marker, Offset1 );
			Draw( graphics, marker, Offset2 );
		}

		//----------------------------------------------------------------------
		void Draw( Graphics graphics, PointF marker, SizeF offset )
		{
			var s = marker - offset;
			var e = marker + offset;

			graphics.DrawLine( Pen, s, e );
		}
	}
}