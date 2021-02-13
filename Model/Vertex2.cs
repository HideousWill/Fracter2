using System.Numerics;

namespace Fracter2.Model
{
	public class Vertex2
	{
		public float   X        => Position.X;
		public float   Y        => Position.Y;
		public Vector2 Position { get; }

		public Vertex2( float x, float y )
		{
			Position = new Vector2( x, y );
		}
	}
}