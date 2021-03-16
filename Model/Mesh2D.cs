using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fracter2.Model
{
	public struct Edge
	{
		public int V1 { get; }
		public int V2 { get; }

		public Edge( int v1, int v2 )
		{
			V1 = v1;
			V2 = v2;
		}
	}

	public struct Triangle
	{
		public int V1 { get; }
		public int V2 { get; }
		public int V3 { get; }

		public Triangle( int v1, int v2, int v3 )
		{
			V1 = v1;
			V2 = v2;
			V3 = v3;
		}
	}

	public interface IEdgeSource
	{
		List< Edge > Edges { get; }
	}

	public class Mesh2D
	{
		//----------------------------------------------------------------------
		public event Action Changed;
		void OnChanged()
		{
			Changed?.Invoke();
		}

		//----------------------------------------------------------------------
		public List< Vertex2 >  Positions { get; } = new List< Vertex2 >();
		public List< Triangle > Triangles { get; } = new List< Triangle >();

		//----------------------------------------------------------------------
		public void Clear()
		{
			Positions.Clear();
			Triangles.Clear();
			StripBuilder.Clear();
			OnChanged();
		}

		//----------------------------------------------------------------------
		public void Add( Vertex2 vertex )
		{
			Positions.Add( vertex );

			StripBuilder.AddVertex( Positions.Count - 1 );

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

		ITriStripBuilder StripBuilder { get; set; } = new NullStripBuilder();

		//----------------------------------------------------------------------
		public IEdgeSource StartStrip()
		{
			StripBuilder = new TriStripBuilder( this );

			return StripBuilder;
		}

		//----------------------------------------------------------------------
		public void EndStrip()
		{
			// Aaand...? Move a strip to a collection of strips?
		}
	}

	internal interface ITriStripBuilder : IEdgeSource
	{
		void Clear();
		void AddVertex( int index );
	}

	class NullStripBuilder : ITriStripBuilder
	{
		public List< Edge > Edges { get; } = new List< Edge >();

		public void Clear()
		{ }

		public void AddVertex( int index )
		{
			// Ha! I care not for your vertices!
		}
	}

	class TriStripBuilder : ITriStripBuilder
	{ 
		Mesh2D Mesh { get; }

		List< int >         AddedVerts { get; } = new List< int >();
		public List< Edge > Edges      { get; } = new List< Edge >();

		//----------------------------------------------------------------------
		public TriStripBuilder( Mesh2D mesh )
		{
			Mesh = mesh;
		}

		//----------------------------------------------------------------------
		public void Clear()
		{
			AddedVerts.Clear();
			Edges.Clear();
		}

		//----------------------------------------------------------------------
		public void AddVertex( int index )
		{
			AddedVerts.Add( index );

			if( 3 >= AddedVerts.Count )
			{
				if( 2 == AddedVerts.Count )
				{
					AddEdge( AddedVerts[ 0 ], AddedVerts[ 1 ] );
				}

				if( 3 == AddedVerts.Count )
				{
					AddEdge( AddedVerts[ 1 ], AddedVerts[ 2 ] );
					AddEdge( AddedVerts[ 2 ], AddedVerts[ 0 ] );
				}

				return;
			}

			var oldest = AddedVerts.Count - 4;
			var prev   = new Triangle( oldest, oldest + 1, oldest + 2 );

			AddTri( AddedVerts.Count - 1, prev );
		}

		//----------------------------------------------------------------------
		void AddEdge( int v1, int v2 )
		{
			Edges.Add( new Edge( v1, v2 ) );
		}

		//----------------------------------------------------------------------
		void AddTri2( int vNew, Triangle prev )
		{
			var newEdge = new Edge( prev.V3, vNew );
			Edges.Add( newEdge );

			var newVec = FromEdge( newEdge );
			var vec3_1 = FromEdge( new Edge( prev.V3, prev.V1 ) );
			var vec3_2 = FromEdge(new Edge(prev.V3, prev.V2));

			var angleToV1 = AngleBetween( newVec, vec3_1 );
			var angleToV2 = AngleBetween( newVec, vec3_2 );

			Console.WriteLine( $"angleToV1: {angleToV1}; angleToV2: {angleToV2}" );

			var vCloseTo = (angleToV1 > 0) ? prev.V1 : prev.V2;
//			var vCloseTo = (angleToV1 > angleToV2) ? prev.V1 : prev.V2;

			Edges.Add( new Edge( vNew, vCloseTo ) );
			// TODO: Need to add a clamp to reject edges that would intersect the tri
		}

		void AddTri( int vNew, Triangle prevTri )
		{
			var prevEdge = Edges[ Edges.Count - 1 ];

			var newEdge = new Edge( prevTri.V3, vNew );
			Edges.Add( newEdge );

			var newVec  = FromEdge( newEdge );
			var prevVec = FromEdge( prevEdge );

			var angle = AngleBetween( newVec, prevVec );

			var vtxCloseTo = (angle > 0) ? prevTri.V1 : prevTri.V2;

			Edges.Add( new Edge( vNew, vtxCloseTo ) );
		}

		//----------------------------------------------------------------------
		Vector2 FromEdge( Edge edge )
		{
			var v1 = Mesh.Positions[ edge.V1 ].Position;
			var v2 = Mesh.Positions[ edge.V2 ].Position;

			return v2 - v1;
		}

		//----------------------------------------------------------------------
		double AngleBetween( Vector2 first, Vector2 second )
		{
			var aTanFirst  = Math.Atan2(first.Y, first.X);
			var aTanSecond = Math.Atan2(second.Y, second.X);

			return aTanSecond - aTanFirst;
		}
	}
}
