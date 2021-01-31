using System;
using System.Collections.Generic;
using System.Drawing;
using Fracter2.View.Drawables;

namespace Fracter2.Data
{
	class DrawableDataGenerator
	{
		//----------------------------------------------------------------------
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

		//----------------------------------------------------------------------
		public Markers GenerateMarkers( float scale = 1f )
		{
			var markers = new Markers();

			markers.Points.AddRange( new List< PointF >()
			{
				new PointF(  1.0f * scale,  1.0f * scale ),
				new PointF( 10.0f * scale,  1.0f * scale ),
				new PointF( 20.0f * scale, 10.0f * scale ),
				new PointF( 10.0f * scale, 20.0f * scale ),
				new PointF( 10.0f * scale, 30.0f * scale ),
			});

			return markers;
		}

		//----------------------------------------------------------------------
		public Markers GenerateRandomMarkers( int count, float scale = 1f, int seed = -1 )
		{
			var rand = (seed < 0) 
				? new Random() 
				: new Random( seed );

			var markers = new  Markers();

			for( var i = 0; i < count; i++ )
			{
				var x = (float) rand.NextDouble();
				var y = (float) rand.NextDouble();

				markers.Points.Add( new PointF( x * scale, y * scale ) );
			}

			return markers;
		}

		//----------------------------------------------------------------------
		public List< PointF > GenerateRandomPoints( int count, float scale = 1f, int seed = -1 )
		{
			var rand = (seed < 0) 
				? new Random() 
				: new Random( seed );

			var points  = new List< PointF >( count );

			for( var i = 0; i < count; i++ )
			{
				var x = (float) rand.NextDouble();
				var y = (float) rand.NextDouble();

				points.Add( new PointF( x * scale, y * scale ) );
			}

			return points;
		}
	}
}
