using System.Drawing;
using System.Drawing.Imaging;
using Fracter2.Data;
using Fracter2.Data.ColorTable;

namespace Fracter2.View.Drawables
{
	public class ImageDrawable : IDrawable
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
		public void Draw( Graphics graphics )
		{
			if( null == Image ) return;

			graphics.DrawImage( Image, ComputeUpperLeft() );
		}

		//----------------------------------------------------------------------
		PointF ComputeUpperLeft()
		{
			if( null == Image ) return new PointF();

//			var posX = (ClientRectangle.Width  - Image.Width)  / 2;
//			var posY = (ClientRectangle.Height - Image.Height) / 2;

			var posX = 0f; // TODO: Figure out how to get a ClientRectangle
			var posY = 0f;

			return new PointF( posX, posY );
		}

		//----------------------------------------------------------------------
		public ImageDrawable( int[,] indices, ColorTableBase palette )
		{
			Palette = palette;
			Indices = indices;
		}

		//----------------------------------------------------------------------
		public void Dispose()
		{
			Image?.Dispose();
		}
	}
}
