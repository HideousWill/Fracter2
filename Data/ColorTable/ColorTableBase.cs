using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fracter2.Data.ColorTable
{
    public abstract class ColorTableBase
    {
	    //---------------------------------------------------------------------
	    public event EventHandler< EventArgs > PaletteChanged;
	    protected virtual void OnPaletteChanged()
	    {
		    var handler = PaletteChanged;
		    handler?.Invoke( this, EventArgs.Empty );
	    }

	    //----------------------------------------------------------------------
        Timer _CycleTimer;
        public Timer CycleTimer
        {
            get => _CycleTimer;
	        set
	        {
		        if( null != _CycleTimer )
		        {
			        _CycleTimer.Tick -= HandleTick;
		        }
		        _CycleTimer = value;
		        if( null != _CycleTimer )
		        {
			        _CycleTimer.Tick += HandleTick;
		        }
	        }
        }

	    //----------------------------------------------------------------------
	    void HandleTick( object sender, EventArgs e )
	    {
		    ++IndexOffset;
		    IndexOffset = IndexOffset % NumberOfColors;
	    }

	    //----------------------------------------------------------------------
	    int _IndexOffset;
	    int IndexOffset
	    {
		    get => _IndexOffset;
		    set { _IndexOffset = value; OnPaletteChanged(); }
	    }

	    //----------------------------------------------------------------------
	    public Color this[ int index ] => Colors[ (index + IndexOffset) % NumberOfColors ];

	    //----------------------------------------------------------------------
        public int NumberOfColors { get; set; }

        //----------------------------------------------------------------------
        public List< Color > Colors { get; private set; }

	    //----------------------------------------------------------------------
	    public bool EnableAnimation
	    {
		    get => CycleTimer.Enabled;
		    set => CycleTimer.Enabled = value;
	    }

	    public int AnimationIntervalMs
	    {
		    get => CycleTimer.Interval;
		    set => CycleTimer.Interval = Math.Max( 1, value );
	    }

        //----------------------------------------------------------------------
        protected ColorTableBase( int numberOfColors )
        {
            Colors = new List< Color >( numberOfColors );
            NumberOfColors = numberOfColors;

	        CycleTimer = new Timer();

	        EnableAnimation     = false;
	        AnimationIntervalMs = 200;
        }

        //----------------------------------------------------------------------
        protected static Color SetMemberColor => Color.Black;

	    //----------------------------------------------------------------------
        protected static float Clamp01( float x )
        {
            return x > 1.0f ? 1.0f : (x < 0f ? 0 : x);
        }
    }
}
