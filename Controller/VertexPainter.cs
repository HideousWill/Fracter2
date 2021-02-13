using System;
using System.Drawing;
using Fracter2.Model;

namespace Fracter2.Controller
{
	public sealed class VertexPainter : IDisposable
	{
		//----------------------------------------------------------------------
		SolidBrush NormalBrush    { get; set; } = new SolidBrush( Color.Red );
		SolidBrush HighlightBrush { get; set; } = new SolidBrush( Color.Yellow );
		SolidBrush DragBrush      { get; set; } = new SolidBrush( Color.Cyan );
		
		Graphics Painter { get; }

		float DrawSize { get; }

		//----------------------------------------------------------------------
		public VertexPainter( Graphics graphics, float drawSize = 3f )
		{
			Painter  = graphics;
			DrawSize = drawSize;
		}

		//----------------------------------------------------------------------
		public void PaintNormal( Vertex2 vertex )
		{
			Painter.FillRectangle( NormalBrush, AsRectF( vertex ) );
		}

		//----------------------------------------------------------------------
		public void PaintHighlight( Vertex2 vertex )
		{
			PaintLarge( vertex, HighlightBrush );
		}

		//----------------------------------------------------------------------
		public void PaintDrag( Vertex2 vertex )
		{
			PaintLarge( vertex, DragBrush );
		}

		//----------------------------------------------------------------------
		void PaintLarge( Vertex2 vertex, Brush brush )
		{
			var rect = AsLargeRectF( vertex );
			Painter.FillRectangle( brush, rect );
			Painter.DrawRectangle( Pens.Black, rect.X, rect.Y, rect.Width, rect.Height );
		}

		//----------------------------------------------------------------------
		RectangleF AsRectF( Vertex2 vertex )
		{
			var halfSize = DrawSize / 2;
			return new RectangleF( vertex.X - halfSize, vertex.Y - halfSize, DrawSize, DrawSize );
		}

		//----------------------------------------------------------------------
		RectangleF AsLargeRectF( Vertex2 vertex )
		{
			return new RectangleF( vertex.X - DrawSize, vertex.Y - DrawSize, DrawSize * 2, DrawSize * 2 );
		}

		//----------------------------------------------------------------------
		public void Dispose()
		{
			NormalBrush?.Dispose();
			HighlightBrush?.Dispose();
			DragBrush?.Dispose();
		}
	}
}