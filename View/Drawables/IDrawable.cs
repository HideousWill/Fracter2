using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.View.Drawables
{
	public interface IDrawable : IDisposable
	{
		List< IDrawModifier > Modifiers { get; }

		void Draw( Graphics graphics );
	}

	public interface IDrawModifier
	{ }

	public class SizeModifier : IDrawModifier
	{
		public float Scale { get; set; } = 1f;
	}

	public class ColorModifier : IDrawModifier
	{
		public Color Color { get; set; } = Color.Magenta;
	}

	public class CenterInControl : IDrawModifier
	{
		protected Control Parent { get; }

		public CenterInControl( Control parent )
		{
			Parent = parent;
		}

		public PointF Apply( int offsetX, int offsetY )
		{
			var clientRect = Parent.ClientRectangle;

			var posX = (clientRect.Width  - offsetX)  / 2;
			var posY = (clientRect.Height - offsetY) / 2;

			return new PointF( posX, posY );
		}
	}

	public class CenterRegionInControl : CenterInControl
	{
		Rectangle Region { get; }

		public CenterRegionInControl( Rectangle region, Control parent ) : base( parent )
		{
			Region = region;
		}

		public List< PointF > Apply( List< PointF > sourcePoints )
		{
			var offsetX = (Parent.ClientRectangle.Width  - Region.Width)  / 2;
			var offsetY = (Parent.ClientRectangle.Height - Region.Height) / 2;
			
			var points = new List< PointF >( sourcePoints.Count );

			foreach( var point in sourcePoints )
			{
				points.Add( new PointF( point.X + offsetX, point.Y + offsetY ) );
			}

			return points;
		}
	}
}
