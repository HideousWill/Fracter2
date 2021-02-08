using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class VeroniAppCtl : UserControl
	{
		public VeroniAppCtl()
		{
			InitializeComponent();
		}

		List< IDrawable > Layers { get; } = new List< IDrawable >();

		void PointEditorToolStripMenuItem_Click( object sender, System.EventArgs e )
		{
			var pointEditor = new PointEditor( DrawableSurface );
			pointEditor.Modifiers.Add( new ColorModifier() {Color = Color.Red} );

			var button = new LayerLegendItem( pointEditor, "Point Editor " + Layers.Count );

			Layers.Add( pointEditor );

			LayerLegend.Add( button );

			DrawableSurface.BackColor = Color.DarkSlateGray;

			DrawableSurface.AddLayer( pointEditor );
			DrawableSurface.DrawLayers();
		}
	}
}
