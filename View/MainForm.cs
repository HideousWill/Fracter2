﻿using System;
using System.Windows.Forms;
using Fracter2.Controller;
using Fracter2.Data;
using Fracter2.Data.ColorTable;
using Fracter2.View.Drawables;

namespace Fracter2.View
{
	public partial class MainForm : Form
	{
		//----------------------------------------------------------------------
		public MainForm()
		{
			InitializeComponent();
		}

		ControlWriter ConsoleWriter { get; set; }

		//----------------------------------------------------------------------
		void MainForm_Load( object sender, EventArgs e )
		{
			ConsoleWriter = new ControlWriter {Target = MyConsole.TextTarget};

			Console.SetOut( ConsoleWriter );
			Console.SetError( ConsoleWriter );
		}

//		DrawableDataGenerator Generator { get; } = new DrawableDataGenerator();
//
//		//----------------------------------------------------------------------
//		void TestImageButton_Click( object sender, EventArgs e )
//		{
//			var pixels = Generator.GenerateIndexedImage();
//
//			var drawable = new ImageDrawable( pixels, new GrayScaleColorTable( 256 ) );
//
//			DrawableCtl.Draw( drawable );
//		}
//
//		//----------------------------------------------------------------------
//		void TestMarkersButton_Click( object sender, EventArgs e )
//		{
//			var markers = Generator.GenerateMarkers( 10f );
//			DrawableCtl.Draw( markers );
//		}
//
//		//----------------------------------------------------------------------
//		void TestLayersButton_Click( object sender, EventArgs e )
//		{
//			var pixels  = Generator.GenerateIndexedImage();
//			var image   = new ImageDrawable( pixels, new GrayScaleColorTable( 256 ) );
//			var markers = Generator.GenerateMarkers( 10f );
//
//			DrawableCtl.AddLayer( image );
//			DrawableCtl.AddLayer( markers );
//			DrawableCtl.DrawLayers();
//		}
//
//		void ColorPickerButton_Click(object sender, EventArgs e)
//		{
//			if( DialogResult.OK == ColorPicker.ShowDialog() )
//			{
//				DrawableCtl.BackgroundColor = ColorPicker.Color;
//			}
//		}
	}
}
