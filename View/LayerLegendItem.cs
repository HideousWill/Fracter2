using System.Windows.Forms;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class LayerLegendItem : UserControl
	{
		public string Text
		{
			get => MyButton.Text;
			set => MyButton.Text = value;
		}

		public IDrawable Drawable { get; set; }

		public LayerLegendItem()
		{
			InitializeComponent();
		}

		public LayerLegendItem( IDrawable layer, string text ) : this()
		{
			Text     = text;
			Drawable = layer;
		}
	}
}
