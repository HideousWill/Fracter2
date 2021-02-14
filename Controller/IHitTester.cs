using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Fracter2.Model;

namespace Fracter2.Controller
{
	public interface IHitTester
	{
		int  Index { get; }
		bool Test( Point p );
	}

	public class VertexHitTester : IHitTester
	{
		List< Vertex2 > Points { get; }

		float Tolerance { get; }

		//----------------------------------------------------------------------
		public VertexHitTester( float tolerance, List< Vertex2 > points )
		{
			Tolerance = tolerance;
			Points    = points;
		}

		//----------------------------------------------------------------------
		public int Index { get; private set; } = -1;

		//----------------------------------------------------------------------
		public bool Test( Point p )
		{
			var pVec        = new Vector2( p.X, p.Y );
			var sizeSquared = Tolerance * Tolerance;

			for( var idx = 0; idx < Points.Count; idx++ )
			{
				var distSq = Vector2.DistanceSquared( pVec, Points[ idx ].Position );

				if( distSq < sizeSquared )
				{
					Index = idx;
					return true;
				}
			}

			Index = -1;
			return false;
		}
	}
}
