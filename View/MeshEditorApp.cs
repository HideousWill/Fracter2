using System.Windows.Forms;
using Fracter2.Controller;

namespace Fracter2.View
{
	public partial class MeshEditorApp : UserControl
	{
		public MeshEditorApp()
		{
			InitializeComponent();
		}

		MeshEditorController EditorController { get; set; }

		void MeshEditorApp_Load(object sender, System.EventArgs e)
		{
			EditorController = new MeshEditorController() { Surface = RootSplitter.Panel2 };
		}
	}
}
