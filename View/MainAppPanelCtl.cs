using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Fracter2.Data;
using Fracter2.Data.ColorTable;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class MainAppPanelCtl : UserControl
	{
		//----------------------------------------------------------------------
		public MainAppPanelCtl()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		DrawableDataGenerator Generator { get; } = new DrawableDataGenerator();

		//----------------------------------------------------------------------
		void TestImageButton_Click( object sender, EventArgs e )
		{
			var pixels = Generator.GenerateIndexedImage();

			var drawable = new ImageDrawable( pixels, new GrayScaleColorTable( 256 ) );

			drawable.Modifiers.Add( new CenterInControl( DrawableCtl ) );

			DrawableCtl.ClearLayers();
			DrawableCtl.AddLayer( drawable );
			DrawableCtl.DrawLayers();
		}

		//----------------------------------------------------------------------
		void TestMarkersButton_Click( object sender, EventArgs e )
		{
			var markers = Generator.GenerateMarkers( 10f );
			
			DrawableCtl.ClearLayers();
			DrawableCtl.AddLayer( markers );
			DrawableCtl.DrawLayers();
		}

		//----------------------------------------------------------------------
		void TestLayersButton_Click( object sender, EventArgs e )
		{
			var pixels = Generator.GenerateIndexedImage();
			var image  = new ImageDrawable( pixels, new GrayScaleColorTable( 256 ) );
			image.Modifiers.Add( new CenterInControl(  DrawableCtl ) );

			var xlate = new CenterRegionInControl( new Rectangle( 0, 0, 256, 256 ), DrawableCtl );

			var points  = Generator.GenerateRandomPoints( 25, 255f );
			
			points.Sort( Sort_Y_X );
			
			var markers = new Markers();
			markers.AddRange( points );
			markers.Modifiers.Add( new SizeModifier {Scale = 5f} );
			markers.Modifiers.Add( new ColorModifier {Color = Color.DarkOrange} );
			markers.Modifiers.Add( xlate );

			var polyline = new Polyline();
			polyline.AddRange( points );
			polyline.Modifiers.Add( new ColorModifier {Color = Color.ForestGreen} );
			polyline.Modifiers.Add( xlate );

			DrawableCtl.ClearLayers();
			DrawableCtl.AddLayer( image );
			DrawableCtl.AddLayer( markers );
			DrawableCtl.AddLayer( polyline );
			DrawableCtl.DrawLayers();
		}

		//----------------------------------------------------------------------
		void EditPointsButton_Click( object sender, EventArgs e )
		{
			DrawableCtl.BackgroundColor = Color.DarkSlateGray;
			
			var pointEditor = new PointEditor( DrawableCtl );
			pointEditor.Modifiers.Add( new ColorModifier {Color = Color.Crimson} );

			pointEditor.PointSelected += i => { Console.WriteLine( $"Selected {pointEditor[ i ]}" ); };
			
			DrawableCtl.ClearLayers();
			DrawableCtl.AddLayer( pointEditor );
			DrawableCtl.DrawLayers();
		}

		//----------------------------------------------------------------------
		int Sort_Y_X( PointF left, PointF right )
		{
			if( left.Y < right.Y ) return -1;
			if( left.Y > right.Y ) return  1;

			if( left.X < right.X ) return -1;
			if( left.X > right.X ) return  1;
			
			return 0;
		}

		//----------------------------------------------------------------------
		void ColorPickerButton_Click( object sender, EventArgs e )
		{
			if( DialogResult.OK == ColorPicker.ShowDialog() )
			{
				DrawableCtl.BackgroundColor = ColorPicker.Color;
			}
		}
	}
}
