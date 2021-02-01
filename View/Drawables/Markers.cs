using System.Drawing;

namespace Fracter2.View.Drawables
{
	public class Markers : DrawablePointFs
	{
		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			base.Draw( graphics );
			
			foreach( var marker in DrawablePoints )
			{
				Draw( graphics, marker );
			}
		}

		SizeF Offset1 { get; } = new SizeF(  1f, 1f );
		SizeF Offset2 { get; } = new SizeF( -1f, 1f );

		//----------------------------------------------------------------------
		void Draw( Graphics graphics, PointF marker )
		{
			base.Draw( graphics );

			var mod = GetMod< SizeModifier >();

			var scale = mod?.Scale ?? 1f;

			var off1 = new SizeF( Offset1.Width * scale, Offset1.Height * scale );
			var off2 = new SizeF( Offset2.Width * scale, Offset2.Height * scale );

			Draw( graphics, marker, off1 );
			Draw( graphics, marker, off2 );
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