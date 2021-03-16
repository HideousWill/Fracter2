using System;
using System.Windows.Forms;

namespace Fracter2.View
{
	public partial class MeshEditorControlPanel : UserControl
	{
		#region Events
		public event EventHandler< string > RadioButtonChanged;
		public event EventHandler           ClearClicked;

		//----------------------------------------------------------------------
		void OnRadioButtonChanged( string token )
		{
			RadioButtonChanged?.Invoke( this, token );
		}

		//----------------------------------------------------------------------
		void OnClearClicked()
		{
			ClearClicked?.Invoke( this, EventArgs.Empty );
		}
		#endregion

		//----------------------------------------------------------------------
		public MeshEditorControlPanel()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		void HandleRadioButtonChanged( object sender, EventArgs e )
		{
			if( (! (sender is RadioButton button)) || ! button.Checked ) return;

			if( ! (button.Tag is string token) )
			{
				token = button.Name;
			}

			OnRadioButtonChanged( token );
		}

		//----------------------------------------------------------------------
		void ClearButton_Click( object sender, EventArgs e )
		{
			OnClearClicked();
		}
	}
}
