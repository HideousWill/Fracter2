using System;
using System.Windows.Forms;
using Fracter2.Controller;
using Fracter2.Model;

namespace Fracter2.View
{
	public partial class MeshEditorApp : UserControl
	{
		//----------------------------------------------------------------------
		public MeshEditorApp()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		partial void OnDispose()
		{
			EditorController                =  null;
			ControlPanel.RadioButtonChanged -= HandleOperationChanged;
			ControlPanel.ClearClicked       += HandleClearClicked;
		}

		//----------------------------------------------------------------------
		void MeshEditorApp_Load( object sender, System.EventArgs e )
		{
			EditorController = new MeshEditorController( Mesh, DrawingSurface );

			ControlPanel.RadioButtonChanged += HandleOperationChanged;
			ControlPanel.ClearClicked       += HandleClearClicked;
		}

		Mesh2D Mesh { get; } = new Mesh2D();

		//----------------------------------------------------------------------
		MeshEditorController _EditorController;

		public MeshEditorController EditorController
		{
			get => _EditorController;
			set
			{
				if( null != _EditorController )
				{
					_EditorController.AddVertexReq    -= HandleAddVertexReq;
					_EditorController.DeleteVertexReq -= HandleDeleteVertexReq;
					_EditorController.MoveVertexReq   -= HandleMoveVertexReq;
					_EditorController.Dispose();
				}

				_EditorController = value;
				if( null != _EditorController )
				{
					_EditorController.AddVertexReq    += HandleAddVertexReq;
					_EditorController.DeleteVertexReq += HandleDeleteVertexReq;
					_EditorController.MoveVertexReq   += HandleMoveVertexReq;
				}
			}
		}

		//----------------------------------------------------------------------
		void HandleAddVertexReq( Vertex2 vertex )
		{
			Mesh.Add( vertex );
		}

		//----------------------------------------------------------------------
		void HandleDeleteVertexReq( int index )
		{
			Mesh.DeleteVertex( index );
		}

		//----------------------------------------------------------------------
		void HandleMoveVertexReq( int index, Vertex2 newPosition )
		{
			Mesh.Move( index, newPosition );
		}

		//----------------------------------------------------------------------
		void HandleOperationChanged( object sender, string e )
		{
			if( e.Contains( "Points" ) )
			{
				Mesh.EndStrip();
				EditorController.EdgeSource = null;
			}
			else if( e.Contains( "Strips" ) )
			{
				EditorController.EdgeSource = Mesh.StartStrip();
			}
		}

		//----------------------------------------------------------------------
		void HandleClearClicked(object sender, EventArgs e)
		{
			Mesh.Clear();
		}
	}
}
