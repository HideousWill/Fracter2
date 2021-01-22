using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class DrawableCtl : UserControl
	{
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

		//----------------------------------------------------------------------
		public void DrawLayers()
		{
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

			foreach( var layer in Layers )
			{
				layer.Draw( e.Graphics );
			}
		}

		//----------------------------------------------------------------------
		protected override void OnResize( EventArgs e )
		{
			base.OnResize( e );
			Invalidate();
		}

		//----------------------------------------------------------------------
		protected override void OnBackColorChanged( EventArgs e )
		{
			base.OnBackColorChanged( e );
			Invalidate();
		}
	}
}
