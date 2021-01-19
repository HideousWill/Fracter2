using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fracter2.Data;

namespace Fracter2.View
{
	public partial class DrawableCtl : UserControl
	{
		//----------------------------------------------------------------------
		IDrawable _Drawable = new NullDrawable();
		IDrawable Drawable
		{
			get => _Drawable;
			set
			{
				_Drawable?.Dispose();
				_Drawable = value;
			}
		}

		List< IDrawable > Layers { get; } = new List< IDrawable >();

		//----------------------------------------------------------------------
		public Color BackgroundColor
		{
			get => BackColor;
			set => BackColor = value;
		}

		//----------------------------------------------------------------------
		public void AddLayer( IDrawable drawable )
		{
			Layers.Add( drawable );
		}

		//----------------------------------------------------------------------
		public void ClearLayers()
		{
			foreach( var layer in Layers )
			{
				layer.Dispose();
			}
			Layers.Clear();
		}

		bool DrawingLayers { get; set; }

		//----------------------------------------------------------------------
		public void DrawLayers()
		{
			DrawingLayers = true;

			Invalidate();
		}

		//----------------------------------------------------------------------
		public void Draw( IDrawable drawable )
		{
			Drawable = drawable;

			Invalidate();
		}

		//----------------------------------------------------------------------
		public DrawableCtl()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );

			if( DrawingLayers )
			{
				DrawingLayers = false;

				foreach( var layer in Layers )
				{
					layer.Draw( e.Graphics );
				}
			}
			else
			{
				Drawable.Draw( e.Graphics );
			}
		}
	}
}
