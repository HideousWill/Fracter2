using System;
using System.Collections.Generic;

namespace Fracter2.Model
{
	public class Edge
	{
		public int V1 { get; }
		public int V2 { get; }
	}

	public class Triangle
	{
		public int V1 { get; }
		public int V2 { get; }
		public int V3 { get; }
	}

	public class Mesh2D
	{
		//----------------------------------------------------------------------
		public event Action Changed;
		void OnChanged()
		{
			Changed?.Invoke();
		}

		public List< Vertex2 > Positions { get; } = new List< Vertex2 >();

		public List< Triangle > Triangles { get; } = new List< Triangle >();

		//----------------------------------------------------------------------
		public void Add( Vertex2 vertex )
		{
			Positions.Add( vertex );

			OnChanged();
		}

		//----------------------------------------------------------------------
		public void DeleteVertex( int index )
		{
			Positions.RemoveAt( index );

			OnChanged();
		}

		//----------------------------------------------------------------------
		public void Move( int index, Vertex2 newPosition )
		{
			Positions[ index ] = newPosition;

			OnChanged();
		}
	}
}
