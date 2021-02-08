using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.View
{
	public partial class LayerLegendCtl : UserControl
	{

		public LayerLegendCtl()
		{
			InitializeComponent();
		}

		public void Add( LayerLegendItem legendItem )
		{
			ButtonHolder.Controls.Add( legendItem );

			LayoutItems();
		}

		void LayoutItems()
		{
			var holder = ButtonHolder.Controls;

			var y = 0;

			for( var i = 0; i < holder.Count; i++ )
			{
				holder[ i ].Location =  new Point( 0, y );
				y += holder[ i ].ClientRectangle.Height;
			}

			ButtonHolder.AutoScrollMinSize = new Size(
				ButtonHolder.AutoScrollMinSize.Width, y );
		}
	}
}
