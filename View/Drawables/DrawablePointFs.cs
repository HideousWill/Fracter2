using System.Collections.Generic;
using System.Drawing;

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

			DrawablePoints = ApplyModifiers();
		}

		//----------------------------------------------------------------------
		protected virtual List< PointF > ApplyModifiers()
		{
			var xlate = GetMod< CenterRegionInControl >();

			return xlate?.Apply( Points ) ?? Points;
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
			Pen = null;
		}
	}
}