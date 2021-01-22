﻿using System;
using System.Drawing;
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

			drawable.Modifiers.Add( new CenterInModifier {Parent = DrawableCtl} );

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
			image.Modifiers.Add( new CenterInModifier {Parent = DrawableCtl} );

			var markers = Generator.GenerateRandomMarkers( 10, 255f );
			markers.Modifiers.Add( new ScaleModifier {Scale = 5f} );
			markers.Modifiers.Add( new ColorModifier {Color = Color.Red} );

			var polyline = new Polyline();
			polyline.Points.AddRange( markers.Points );
			polyline.Modifiers.Add( new ColorModifier {Color = Color.SlateBlue} );

			DrawableCtl.ClearLayers();
			DrawableCtl.AddLayer( image );
			DrawableCtl.AddLayer( markers );
			DrawableCtl.AddLayer( polyline );
			DrawableCtl.DrawLayers();
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
