using System.Collections.Generic;
using System.Windows.Forms;
using Fracter2.Controller;
using Fracter2.Model;

namespace Fracter2.View
{
	public partial class MeshEditorApp : UserControl
	{
		public MeshEditorApp()
		{
			InitializeComponent();
		}

		MeshEditorController EditorController { get; set; }

		Mesh2D Mesh { get; } = new Mesh2D();

		void MeshEditorApp_Load( object sender, System.EventArgs e )
		{
			EditorController = new MeshEditorController( Mesh, DrawingSurface );
		}
	}
}
