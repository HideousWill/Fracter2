using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.View.Drawables
{
	public class PointEditor : DrawablePointFs
	{
		//----------------------------------------------------------------------
		public Action< int > PointSelected;
		void OnPointSelected( int index )
		{
			PointSelected?.Invoke( index );
		}
		
		//----------------------------------------------------------------------
		Control _Owner;
		Control Owner
		{
			get => _Owner;
			set
			{
				if( null != _Owner )
				{
					_Owner.MouseDown -= HandleMouseDown;
					_Owner.MouseUp   -= HandleMouseUp;
					_Owner.MouseMove -= HandleMouseMove;
				}

				_Owner = value;
				if( null != _Owner )
				{
					_Owner.MouseDown += HandleMouseDown;
					_Owner.MouseUp   += HandleMouseUp;
					_Owner.MouseMove += HandleMouseMove;
				}
			}
		}

		bool IsMouseDown { get; set; }
		bool IsInside    { get; set; }

		Point MouseDownLocation { get; set; }
		
		//----------------------------------------------------------------------
		void HandleMouseDown( object sender, MouseEventArgs e )
		{
			IsMouseDown       = true;
			MouseDownLocation = e.Location;

			if( ! HitTest( e.Location ) ) return;
			
			Action       = MouseAction.Drag;
			Owner.Cursor = Cursors.Hand;
			Owner.Invalidate();
			
			OnPointSelected( PickHit );
		}

		//----------------------------------------------------------------------
		void HandleMouseUp( object sender, MouseEventArgs e )
		{
			IsMouseDown = false;

			if( ! IsInside ) return;

			if( MouseAction.Drag != Action )
			{
				Add( new PointF( e.X, e.Y ) );
				Owner.Invalidate();
			}
			else if( IsDeleteRequest )
			{
				RemoveAt( PickHit );
				Owner.Invalidate();
			}

			Owner.ResetCursor();

			if( 0 == Count % 10 )
			{
				Console.WriteLine( $"Points.Count = {Count}" );
			}
		}

		//----------------------------------------------------------------------
		bool IsDeleteRequest =>
			PickHit >= 0 &&
			0       != (Keys.Control & Control.ModifierKeys);

		//----------------------------------------------------------------------
		void HandleMouseMove( object sender, MouseEventArgs e )
		{
			IsInside = Owner.ClientRectangle.Contains( e.Location );

			if( ! IsInside ) return;
			
			if( IsMouseDown ) { DoMoveMouseDown( e ); }
			else              { DoMoveMouseUp( e ); }
		}

		//----------------------------------------------------------------------
		void DoMoveMouseUp( MouseEventArgs e )
		{
			var action = HitTest( e.Location ) 
				? MouseAction.Highlight
				: MouseAction.Normal;

			if( action == Action ) return;
			
			Action = action;
			Owner.Invalidate();
		}

		//----------------------------------------------------------------------
		void DoMoveMouseDown( MouseEventArgs e )
		{
			if( PickHit < 0 ) return;

			if( e.Location == MouseDownLocation ) return;
			
			this[ PickHit ] = new PointF( e.X, e.Y );
			Owner.Invalidate();
		}

		//----------------------------------------------------------------------
		bool HitTest( Point p )
		{
			for( var idx = 0; idx < Count; idx++ )
			{
				var x = this[ idx ].X - p.X;
				var y = this[ idx ].Y - p.Y;

				var length = Math.Sqrt( x * x + y * y );

				if( length < DrawSize )
				{
					PickHit = idx;
					return true;
				}
			}

			PickHit = -1;
			return false;
		}

		//----------------------------------------------------------------------
		enum MouseAction
		{
			Normal,
			Highlight,
			Drag
		}
		
		MouseAction Action   { get; set; }
		int         PickHit  { get; set; } = -1;
		float       DrawSize { get; set; } = 3f;
		
		//----------------------------------------------------------------------
		SolidBrush HighlightBrush { get; set; } = new SolidBrush( Color.Coral );
		SolidBrush DragBrush      { get; set; } = new SolidBrush( Color.Yellow );
		
		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			base.Draw( graphics );

			using( var normalBrush = new SolidBrush( Pen.Color ) )
			{
				var halfSize = DrawSize / 2;

				for( var i = 0; i < Count; i++ )
				{
					var point = this[ i ];
					if( i == PickHit )
					{
						graphics.FillRectangle( MouseAction.Drag != Action ? HighlightBrush : DragBrush,
						                        point.X - DrawSize, point.Y - DrawSize,
						                        DrawSize * 2, DrawSize * 2 );

						graphics.DrawRectangle( Pens.Black,
						                        point.X - DrawSize, point.Y - DrawSize,
						                        DrawSize * 2, DrawSize * 2 );
					}
					else
					{
						graphics.FillRectangle( normalBrush,
						                        point.X - halfSize, point.Y - halfSize,
						                        DrawSize, DrawSize );
					}
				}
			}
		}

		//----------------------------------------------------------------------
		public PointEditor( Control owner )
		{
			Owner = owner;
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( IsDisposed ) return;
			
			base.Dispose( disposing );
			
			DragBrush.Dispose();
			HighlightBrush.Dispose();
			
			Owner = null;
		}
	}
}
