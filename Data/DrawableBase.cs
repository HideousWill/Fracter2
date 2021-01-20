using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fracter2.Data
{
	public abstract class DrawableBase : IDrawable
	{
		public List< IDrawModifier > Modifiers { get; } = new List< IDrawModifier >();

		//----------------------------------------------------------------------
		public abstract void Draw( Graphics graphics );

		//----------------------------------------------------------------------
		protected T GetMod< T >() where T : class, IDrawModifier
		{
			return Modifiers?.Find( m => m.GetType() == typeof( T ) ) as T;
		}

		protected bool IsDisposed { get; private set; }

		//----------------------------------------------------------------------
		protected virtual void Dispose( bool disposing )
		{
			if( IsDisposed ) return;

			if( disposing )
			{
				IsDisposed = true;
			}
		}

		//----------------------------------------------------------------------
		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}
	}

	public class NullDrawable : DrawableBase
	{
		public override void Draw( Graphics graphics )
		{}
	}
}