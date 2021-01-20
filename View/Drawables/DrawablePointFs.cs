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

		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			var c = GetMod< ColorModifier >();

			if( null != c )
			{
				Pen = new Pen( c.Color );
			}
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
			Pen = null;
		}
	}
}