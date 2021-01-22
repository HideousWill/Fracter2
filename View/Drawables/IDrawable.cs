using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.View.Drawables
{
	public interface IDrawable : IDisposable
	{
		List< IDrawModifier > Modifiers { get; }

		void Draw( Graphics graphics );
	}

	public interface IDrawModifier
	{ }

	public class ScaleModifier : IDrawModifier
	{
		public float Scale { get; set; } = 1f;
	}

	public class ColorModifier : IDrawModifier
	{
		public Color Color { get; set; } = Color.Magenta;
	}

	public class CenterInModifier : IDrawModifier
	{
		public Control   Parent { get; set; }
	}
}
