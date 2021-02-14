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
		public Action< int > PointSelected;
		void OnPointSelected( int index )
		{
			PointSelected?.Invoke( index );
		}

		//----------------------------------------------------------------------
		Mesh2D          Mesh   { get; }
		List< Vertex2 > Points => Mesh.Positions;

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
				Points.Add( new Vertex2( e.X, e.Y ) );
				Invalidate();
			}
			else if( IsDeleteRequest )
			{
				Points.RemoveAt( PickHit );
				Invalidate();
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

			Points[ PickHit ] = new Vertex2( e.X, e.Y );
			Invalidate();
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