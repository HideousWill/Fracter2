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


		UserControl _ActiveControl;
		public UserControl ActiveControl
		{
			get { return _ActiveControl; }
			set
			{
				if( null != _ActiveControl )
				{
					_ActiveControl.Dispose();
				}
				_ActiveControl = value;
				if( null != _ActiveControl )
				{
					_ActiveControl.Parent = RootSplitter.Panel1;
					_ActiveControl.Dock = DockStyle.Fill;
				}
			}
		}

		void VeroniMenuItem_Click(object sender, System.EventArgs e)
		{
			ActiveControl = new VeroniAppCtl();
		}

		private void OldCountryMenuItem_Click(object sender, EventArgs e)
		{
			ActiveControl = new MainAppPanelCtl();
		}

		private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			Console.WriteLine( $"Item clicked: {e.ClickedItem}" );
		}
	}
}