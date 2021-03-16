using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fracter2.Model;

namespace Fracter2.Controller
{
	public class MeshEditorController : IDisposable
	{
		//----------------------------------------------------------------------
		public event Action< int > VertexSelected;
		void OnPointSelected( int index )
		{
			VertexSelected?.Invoke( index );
		}

		//----------------------------------------------------------------------
		public event Action< Vertex2 > AddVertexReq;
		void OnAddVertexReq( Vertex2 vertex )
		{
			AddVertexReq?.Invoke( vertex );
		}

		//----------------------------------------------------------------------
		public event Action< int > DeleteVertexReq;
		void OnDeleteVertexReq( int index )
		{
			DeleteVertexReq?.Invoke( index );
		}

		//----------------------------------------------------------------------
		public event Action< int, Vertex2 > MoveVertexReq;
		void OnMoveVertexReq( int index, Vertex2 newPosition )
		{
			MoveVertexReq?.Invoke( index, newPosition );
		}

		//----------------------------------------------------------------------
		List< Vertex2 > Points => Mesh.Positions;

		//----------------------------------------------------------------------
		Mesh2D _Mesh;
		public Mesh2D Mesh
		{
			get => _Mesh;
			set
			{
				if( null != _Mesh )
				{
					_Mesh.Changed -= HandleMeshChanged;
				}
				_Mesh = value;
				if( null != _Mesh )
				{
					_Mesh.Changed += HandleMeshChanged;
				}
			}
		}

		public IEdgeSource EdgeSource { get; set; }

		//----------------------------------------------------------------------
		Control _Surface;
		public Control Surface
		{
			get => _Surface;
			set
			{
				if( null != _Surface )
				{
					_Surface.MouseDown -= HandleMouseDown;
					_Surface.MouseUp   -= HandleMouseUp;
					_Surface.MouseMove -= HandleMouseMove;
					_Surface.Paint     -= HandlePaint;
				}

				_Surface = value;
				if( null != _Surface )
				{
					_Surface.MouseDown += HandleMouseDown;
					_Surface.MouseUp   += HandleMouseUp;
					_Surface.MouseMove += HandleMouseMove;
					_Surface.Paint     += HandlePaint;
				}
			}
		}

		//----------------------------------------------------------------------
		void HandleMeshChanged()
		{
			Invalidate();
		}

		//----------------------------------------------------------------------
		void HandlePaint( object sender, PaintEventArgs e )
		{
			Draw( e.Graphics );
		}

		//----------------------------------------------------------------------
		bool IsMouseDown { get; set; }
		bool IsInside    { get; set; }

		Point MouseDownLocation { get; set; }

		//----------------------------------------------------------------------
		void HandleMouseDown( object sender, MouseEventArgs e )
		{
			IsMouseDown       = true;
			MouseDownLocation = e.Location;

			if( ! HitTester.Test( e.Location ) ) return;

			Action         = MouseAction.Drag;
			Surface.Cursor = Cursors.Hand;
			Invalidate();

			OnPointSelected( PickHit );
		}

		//----------------------------------------------------------------------
		void HandleMouseUp( object sender, MouseEventArgs e )
		{
			IsMouseDown = false;

			if( ! IsInside ) return;

			if( MouseAction.Drag != Action &&
			    IsAddRequest )
			{
				OnAddVertexReq( new Vertex2( e.X, e.Y ) );
			}
			else if( IsDeleteRequest )
			{
				OnDeleteVertexReq( PickHit );
			}

			Surface.ResetCursor();
		}

		//----------------------------------------------------------------------
		void HandleMouseMove( object sender, MouseEventArgs e )
		{
			IsInside = Surface.ClientRectangle.Contains( e.Location );

			if( ! IsInside ) return;

			if( IsMouseDown )
			{
				DoMoveMouseDown( e );
			}
			else
			{
				DoMoveMouseUp( e );
			}
		}

		//----------------------------------------------------------------------
		void DoMoveMouseUp( MouseEventArgs e )
		{
			var action = HitTester.Test( e.Location )
				? MouseAction.Highlight
				: MouseAction.Normal;

			if( action == Action ) return;

			Action = action;
			Invalidate();
		}

		//----------------------------------------------------------------------
		void DoMoveMouseDown( MouseEventArgs e )
		{
			if( PickHit < 0 ) return;

			if( e.Location == MouseDownLocation ) return;

			OnMoveVertexReq( PickHit, new Vertex2( e.X, e.Y ) );
		}

		//----------------------------------------------------------------------
		bool IsAddRequest =>
			0 != (Keys.Shift & Control.ModifierKeys);

		//----------------------------------------------------------------------
		bool IsDeleteRequest =>
			PickHit >= 0 &&
			0       != (Keys.Control & Control.ModifierKeys);

		//----------------------------------------------------------------------
		enum MouseAction
		{
			Normal,
			Highlight,
			Drag
		}

		MouseAction Action   { get; set; }
		float       DrawSize { get; set; } = 3f;

		//----------------------------------------------------------------------
		void Draw( Graphics graphics )
		{
			using( var painter = new VertexPainter( graphics, DrawSize ) )
			{
				for( var i = 0; i < Points.Count; i++ )
				{
					if( i != PickHit )
					{
						painter.PaintNormal( Points[ i ] );
					}
					else
					{
						if( MouseAction.Drag == Action )
							painter.PaintDrag( Points[ i ] );
						else
							painter.PaintHighlight( Points[ i ] );
					}
				}
			}

			DrawEdges( graphics );
		}

		//----------------------------------------------------------------------
		void DrawEdges( Graphics graphics )
		{
			if( null == EdgeSource ) return;

			int i = 0;

			for( i = 0; i < EdgeSource.Edges.Count; i++ )
			{
				var edge = EdgeSource.Edges[ i ];

				var pen = (i == EdgeSource.Edges.Count - 1)
					? Pens.Cyan
					: Pens.AntiqueWhite;

				DrawEdge( graphics, edge, pen );
			}

			//			foreach ( var edge in EdgeSource.Edges )
			//			{
			//				var v1 = Points[ edge.V1 ];
			//				var v2 = Points[ edge.V2 ];
			//
			//				graphics.DrawLine( Pens.AntiqueWhite, 
			//				                   new PointF( v1.X, v1.Y ), 
			//				                   new PointF( v2.X, v2.Y ) );
			//			}
		}

		void DrawEdge( Graphics graphics, Edge edge, Pen pen )
		{
			var v1 = Points[ edge.V1 ];
			var v2 = Points[ edge.V2 ];

			graphics.DrawLine( pen,
			                   new PointF( v1.X, v1.Y ),
			                   new PointF( v2.X, v2.Y ) );
		}

		//----------------------------------------------------------------------
		int        PickHit   => HitTester.Index;
		IHitTester HitTester { get; }

		//----------------------------------------------------------------------
		void Invalidate()
		{
			Surface.Invalidate();
		}

		//----------------------------------------------------------------------
		public MeshEditorController( Mesh2D mesh, Control surface )
		{
			Mesh      = mesh;
			Surface   = surface;
			HitTester = new VertexHitTester( DrawSize, Points );
		}

		//----------------------------------------------------------------------
		public void Dispose()
		{
			_Surface?.Dispose();
			_Surface = null;
		}
	}
}