using System.Collections.Generic;
using System.Drawing;
using Fracter2.View.Drawables;

namespace Fracter2.Data
{
	class DrawableDataGenerator
	{
		public int[,] GenerateIndexedImage()
		{
			var pixels = new int[256, 256];

			for( var row = 0; row < 256; row++ )
				for( var col = 0; col < 256; col++ )
				{
					var x = (row * 2) % 256 + col;
					if( x >= 256 )
					{
						var y = x - 256;
						x = 256 - y;
					}
					pixels[ row, col ] = x;
				}

			return pixels;
		}

		public Markers GenerateMarkers( float scale = 1f )
		{
			var markers = new Markers();

			markers.AddRange( new List< PointF >()
			{
				new PointF(  1.0f * scale,  1.0f * scale ),
				new PointF( 10.0f * scale,  1.0f * scale ),
				new PointF( 20.0f * scale, 10.0f * scale ),
				new PointF( 10.0f * scale, 20.0f * scale ),
				new PointF( 10.0f * scale, 30.0f * scale ),
			});

			return markers;
		}
	}
}
