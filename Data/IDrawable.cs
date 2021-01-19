using System;
using System.Drawing;

namespace Fracter2.Data
{
	public interface IDrawable : IDisposable
	{
		void Draw( Graphics graphics );
	}

	public sealed class NullDrawable : IDrawable
	{
		public void Draw( Graphics graphics )
		{ }

		public void Dispose()
		{ }
	}
}
