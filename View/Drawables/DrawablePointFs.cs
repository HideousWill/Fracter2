using System;
using System.Collections.Generic;
using System.Drawing;
using Fracter2.Data;

namespace Fracter2.View.Drawables
{
	public abstract class DrawablePointFs : List< PointF >, IDrawable
	{
		//----------------------------------------------------------------------
		public Pen Pen { get; set; }

		//----------------------------------------------------------------------
		public abstract void Draw( Graphics graphics );

		//----------------------------------------------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		bool IsDisposed { get; set; }

		//----------------------------------------------------------------------
		protected virtual void Dispose( bool disposing )
		{
			if( IsDisposed ) return;

			if( disposing )
			{
				IsDisposed = true;
				Pen?.Dispose();
			}
		}
	}
}