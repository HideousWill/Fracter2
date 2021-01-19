using System;
using System.Windows.Forms;
using Fracter2.Controller;
using Fracter2.Data;
using Fracter2.Data.ColorTable;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class MainForm : Form
	{
		//----------------------------------------------------------------------
		public MainForm()
		{
			InitializeComponent();
		}

		ControlWriter ConsoleWriter { get; set; }

		//----------------------------------------------------------------------
		void MainForm_Load( object sender, EventArgs e )
		{
			ConsoleWriter = new ControlWriter {Target = MyConsole.TextTarget};

			Console.SetOut( ConsoleWriter );
			Console.SetError( ConsoleWriter );
		}
	}
}
