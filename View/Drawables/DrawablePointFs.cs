using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Fracter2.View.Drawables
{
	public interface IPointFList : IList< PointF >
	{
		event Action< int > PointAdded;
		event Action< int > PointRemoved;
		void                AddRange( IEnumerable< PointF > points );
	}

	public abstract class DrawablePointFs : DrawableBase, IPointFList
	{
		#region IPointList implementation
		//----------------------------------------------------------------------
		public event Action< int > PointAdded;
		protected void OnPointAdded( int index )
		{
			PointAdded?.Invoke( index );
		}

		//----------------------------------------------------------------------
		public event Action< int > PointRemoved;
		protected void OnPointRemoved( int index )
		{
			PointRemoved?.Invoke( index );
		}

		//----------------------------------------------------------------------
		public void AddRange( IEnumerable< PointF > points )
		{
			Points.AddRange( points );
		}

		#region IList<> implementation

		//----------------------------------------------------------------------
		public IEnumerator< PointF > GetEnumerator()
		{
			return Points.GetEnumerator();
		}

		//----------------------------------------------------------------------
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		//----------------------------------------------------------------------
		public void Add( PointF item )
		{
			Points.Add( item );
			OnPointAdded( Count - 1 );
		}

		//----------------------------------------------------------------------
		public void Clear()
		{
			Points.Clear();
		}

		//----------------------------------------------------------------------
		public bool Contains( PointF item )
		{
			return Points.Contains( item );
		}

		//----------------------------------------------------------------------
		public void CopyTo( PointF[] array, int arrayIndex )
		{
			Points.CopyTo( array, arrayIndex );
		}

		//----------------------------------------------------------------------
		public bool Remove( PointF item )
		{
			var index = Points.FindIndex( p => p == item );
			
			if( index < 0 ) return false;
			
			Points.RemoveAt( index );
			return true;
		}

		//----------------------------------------------------------------------
		public int  Count      => Points.Count;
		public bool IsReadOnly => false;

		//----------------------------------------------------------------------
		public int IndexOf( PointF item )
		{
			return Points.IndexOf( item );
		}

		//----------------------------------------------------------------------
		public void Insert( int index, PointF item )
		{
			Points.Insert( index, item );
			OnPointAdded( index );
		}

		//----------------------------------------------------------------------
		public void RemoveAt( int index )
		{
			Points.RemoveAt( index );
			OnPointRemoved( index );
		}

		//----------------------------------------------------------------------
		public PointF this[ int index ]
		{
			get => Points[ index ];
			set => Points[ index ] = value;
		}

		#endregion
		#endregion

		//----------------------------------------------------------------------
		Pen _Pen = new Pen( Color.Magenta );
		protected Pen Pen
		{
			get => _Pen;
			set
			{
				_Pen?.Dispose();
				_Pen = value;
			}
		}

		//----------------------------------------------------------------------
		List< PointF > Points { get; } = new List< PointF >();

		protected List< PointF > DrawablePoints { get; private set; }

		//----------------------------------------------------------------------
		public override void Draw( Graphics graphics )
		{
			var c = GetMod< ColorModifier >();

			if( null != c )
			{
				Pen = new Pen( c.Color );
			}

			DrawablePoints = ApplyModifiers();
		}

		//----------------------------------------------------------------------
		protected virtual List< PointF > ApplyModifiers()
		{
			var xlate = GetMod< CenterRegionInControl >();

			return xlate?.Apply( Points ) ?? Points;
		}

		//----------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
			Pen = null;
		}
	}
}