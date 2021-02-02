using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.View.Drawables
{
	public class PointEditor : DrawablePointFs
	{
		//----------------------------------------------------------------------
		Control _Owner;
		Control Owner
		{
			get { return _Owner; }
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

			if( PickTest( e.Location ) )
			{
				Action = MouseAction.Drag;
				Console.WriteLine( "vvv Start Drag" );
			}
		}

		//----------------------------------------------------------------------
		void HandleMouseUp( object sender, MouseEventArgs e )
		{
			IsMouseDown = false;

			if( ! IsInside ) return;

			if( MouseAction.Drag != Action )
			{
				Points.Add( new PointF( e.X, e.Y ) );
				Owner.Invalidate();
			}
			
			if( 0 == Points.Count % 10 )
			{
				Console.WriteLine( $"Points.Count = {Points.Count}" );
			}
		}

		//----------------------------------------------------------------------
		void HandleMouseMove( object sender, MouseEventArgs e )
		{
			IsInside = Owner.ClientRectangle.Contains( e.Location );

			if( ! IsInside ) return;

			if( MouseAction.Normal != Action &&
			    ! IsMouseDown )
			{
				Action = PickTest( e.Location )
					? MouseAction.Highlight
					: MouseAction.Normal;
			}

			switch( Action )
			{
				case MouseAction.Normal:
				case MouseAction.Highlight:
					Action = PickTest( e.Location )
						? MouseAction.Highlight
						: MouseAction.Normal;
					break;
				case MouseAction.Drag:
					Points[ PickHit ] = new PointF( e.X, e.Y );
					Owner.Invalidate();
					break;
			}
		}

		//----------------------------------------------------------------------
		bool PickTest( Point p )
		{
			for( var i = 0; i < Points.Count; i++ )
			{
				var x = Points[ i ].X - p.X;
				var y = Points[ i ].Y - p.Y;

				var length = Math.Sqrt( x * x + y * y );

				if( length < DrawSize )
				{
					PickHit = i;
					Owner.Invalidate();
					return true;
				}
			}

			if( PickHit >= 0 ) Owner.Invalidate();
			PickHit = -1;
			return false;
		}

		enum MouseAction
		{
			Normal,
			Highlight,
			Drag
		}
		
		MouseAction Action   { get; set; }
		int         PickHit  { get; set; } = -1;
		float       DrawSize { get; set; } = 3f;
		
		SolidBrush HighlightBrush { get; set; } = new SolidBrush( Color.Coral );
		SolidBrush DragBrush      { get; set; } = new SolidBrush( Color.Yellow );
		
		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			base.Draw( graphics );

			using( var normalBrush = new SolidBrush( Pen.Color ) )
			{
				var halfSize = DrawSize / 2;

				for( var i = 0; i < Points.Count; i++ )
				{
					var point = Points[ i ];
					if( i == PickHit )
					{
						var brush = (MouseAction.Drag == Action) ? DragBrush : HighlightBrush;
						
						graphics.FillRectangle( brush,
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
