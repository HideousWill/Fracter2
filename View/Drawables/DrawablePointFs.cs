using System.Collections.Generic;
using System.Drawing;
using Fracter2.Data;

namespace Fracter2.View.Drawables
{
	public abstract class DrawablePointFs : DrawableBase
	{
		//----------------------------------------------------------------------
		Pen _Pen = new Pen( Color.Magenta );
		public Pen Pen
		{
			get => _Pen;
			set
			{
				_Pen?.Dispose();
				_Pen = value;
			}
		}

		//----------------------------------------------------------------------
		public List< PointF > Points { get; } = new List< PointF >();

		protected List< PointF > DrawablePoints { get; private set; }

		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			var c = GetMod< ColorModifier >();

			if( null != c )
			{
				Pen = new Pen( c.Color );
			}

			DrawablePoints = ResolvePoints();
		}

		List< PointF > ResolvePoints()
		{
			var xlate = GetMod< TranslateModifier >();

			if( null == xlate ) return Points;

			var offsetX = (xlate.Parent.ClientRectangle.Width - xlate.Bounds.Width) / 2;
			var offsetY = (xlate.Parent.ClientRectangle.Height - xlate.Bounds.Height) / 2;
			
			var points = new List< PointF >( Points.Count );

			foreach( var point in Points )
			{
				points.Add( new PointF( point.X + offsetX, point.Y + offsetY ) );
			}
			
			return points;
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
			Pen = null;
		}
	}
}