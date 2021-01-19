using System.Windows.Forms;

namespace Fracter2.View
{
	public partial class ConsoleCtl : UserControl
	{
		public Control TextTarget => TheText;

		public ConsoleCtl()
		{
			InitializeComponent();
		}
	}
}
