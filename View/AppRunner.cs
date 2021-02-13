using System;
using System.Windows.Forms;
using Fracter2.Controller;

namespace Fracter2.View
{
	public partial class AppRunner : Form
	{
		public AppRunner()
		{
			InitializeComponent();
		}

		TextBoxWriter ConsoleWriter { get; set; }

		void ApplicationHost_Load(object sender, EventArgs e)
		{
			ConsoleWriter = new TextBoxWriter(ConsoleTextBox);

			Console.SetOut(ConsoleWriter);
			Console.SetError(ConsoleWriter);
		}


		UserControl _ActiveAppControl;
		public UserControl ActiveAppControl
		{
			get => _ActiveAppControl;
			set
			{
				if( null != _ActiveAppControl )
				{
					_ActiveAppControl.Dispose();
				}
				_ActiveAppControl = value;
				if( null != _ActiveAppControl )
				{
					_ActiveAppControl.Parent = RootSplitter.Panel1;
					_ActiveAppControl.Dock = DockStyle.Fill;
				}
			}
		}

		void VeroniMenuItem_Click(object sender, EventArgs e)
		{
			ActiveAppControl = new VeroniAppCtl();
		}

		void OldCountryMenuItem_Click(object sender, EventArgs e)
		{
			ActiveAppControl = new MainAppPanelCtl();
		}

		void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			Console.WriteLine( $"Item clicked: {e.ClickedItem}" );
		}

		private void MeshEditorMenuItem_Click(object sender, EventArgs e)
		{
			ActiveAppControl = new MeshEditorApp();
		}
	}
}