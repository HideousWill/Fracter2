using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Fracter2.Controller
{
	public class ControlWriter : TextWriter
	{
		public Control Target { get; set; }

		public override Encoding Encoding => Encoding.UTF8;

		public override void Write( char value )
		{
			Target.Text += value;
		}

		public override void Write( string value )
		{
			Target.Text += value;
		}
	}
}
