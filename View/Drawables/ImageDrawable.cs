using System.Drawing;
using System.Drawing.Imaging;
using Fracter2.Data.ColorTable;

namespace Fracter2.View.Drawables
{
	public class ImageDrawable :  DrawableBase
	{
		//----------------------------------------------------------------------
		int[,] _Indices;
		int[,] Indices
		{
			get => _Indices;
			set
			{
				_Indices = value;

				var h = _Indices.GetLength( 0 );
				var w = _Indices.GetLength( 1 );

				if( null != Image )
				{
					if( w != Image.Width ||
					    h != Image.Height )
					{
						Image.Dispose();
						Image = null;
					}
				}

				if( null == Image )
				{
					Image = new Bitmap( w, h, PixelFormat.Format32bppArgb );
				}

				for( var row = 0; row < h; row++ )
					for( var col = 0; col < w; col++ )
					{
						var idx = _Indices[ row, col ];
						Image.SetPixel( col, row, Palette[ idx ] );
					}
			}
		}

		//----------------------------------------------------------------------
		Bitmap         Image   { get; set; }
		ColorTableBase Palette { get; set; }

		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			if( null == Image ) return;

			graphics.DrawImage( Image, ComputeUpperLeft() );
		}

		//----------------------------------------------------------------------
		PointF ComputeUpperLeft()
		{
			if( null == Image ) return new PointF();

			var centerer = GetMod< CenterInModifier >();

			if( null == centerer ) return new PointF();

			var clientRect = centerer.Parent.ClientRectangle;

			var posX = (clientRect.Width  - Image.Width)  / 2;
			var posY = (clientRect.Height - Image.Height) / 2;

			return new PointF( posX, posY );
		}

		//----------------------------------------------------------------------
		public ImageDrawable( int[,] indices, ColorTableBase palette )
		{
			Palette = palette;
			Indices = indices;
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( IsDisposed ) return;

			base.Dispose( disposing );

			Image?.Dispose();
		}
	}
}
