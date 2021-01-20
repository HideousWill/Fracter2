﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fracter2.Data
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
		public Rectangle Rect { get; set; } = new Rectangle();
	}
}
