namespace Fracter2.View
{
	partial class MainAppPanelCtl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainSplitter      = new System.Windows.Forms.SplitContainer();
			this.ColorPickerButton = new System.Windows.Forms.Button();
			this.TestLayersButton  = new System.Windows.Forms.Button();
			this.TestMarkersButton = new System.Windows.Forms.Button();
			this.TestImageButton   = new System.Windows.Forms.Button();
			this.DrawableCtl       = new Fracter2.View.DrawableCtl();
			this.ColorPicker       = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize) (this.MainSplitter)).BeginInit();
			this.MainSplitter.Panel1.SuspendLayout();
			this.MainSplitter.Panel2.SuspendLayout();
			this.MainSplitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainSplitter
			// 
			this.MainSplitter.Anchor      = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.MainSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainSplitter.Location    = new System.Drawing.Point( 0, 0 );
			this.MainSplitter.MinimumSize = new System.Drawing.Size( 100, 100 );
			this.MainSplitter.Name        = "MainSplitter";
			// 
			// MainSplitter.Panel1
			// 
			this.MainSplitter.Panel1.AutoScroll        = true;
			this.MainSplitter.Panel1.AutoScrollMinSize = new System.Drawing.Size( 60, 120 );
			this.MainSplitter.Panel1.Controls.Add( this.ColorPickerButton );
			this.MainSplitter.Panel1.Controls.Add( this.TestLayersButton );
			this.MainSplitter.Panel1.Controls.Add( this.TestMarkersButton );
			this.MainSplitter.Panel1.Controls.Add( this.TestImageButton );
			this.MainSplitter.Panel1MinSize = 100;
			// 
			// MainSplitter.Panel2
			// 
			this.MainSplitter.Panel2.AutoScroll        = true;
			this.MainSplitter.Panel2.AutoScrollMinSize = new System.Drawing.Size( 256, 256 );
			this.MainSplitter.Panel2.Controls.Add( this.DrawableCtl );
			this.MainSplitter.Panel2MinSize    = 100;
			this.MainSplitter.Size             = new System.Drawing.Size( 400, 300 );
			this.MainSplitter.SplitterDistance = 100;
			this.MainSplitter.TabIndex         = 0;
			// 
			// ColorPickerButton
			// 
			this.ColorPickerButton.Anchor                  =  ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ColorPickerButton.Location                =  new System.Drawing.Point( 4, 272 );
			this.ColorPickerButton.Name                    =  "ColorPickerButton";
			this.ColorPickerButton.Size                    =  new System.Drawing.Size( 89, 23 );
			this.ColorPickerButton.TabIndex                =  8;
			this.ColorPickerButton.Text                    =  "BG Color";
			this.ColorPickerButton.UseVisualStyleBackColor =  true;
			this.ColorPickerButton.Click                   += new System.EventHandler( this.ColorPickerButton_Click );
			// 
			// TestLayersButton
			// 
			this.TestLayersButton.Location                =  new System.Drawing.Point( 4, 62 );
			this.TestLayersButton.Name                    =  "TestLayersButton";
			this.TestLayersButton.Size                    =  new System.Drawing.Size( 89, 23 );
			this.TestLayersButton.TabIndex                =  7;
			this.TestLayersButton.Text                    =  "Test Layers";
			this.TestLayersButton.UseVisualStyleBackColor =  true;
			this.TestLayersButton.Click                   += new System.EventHandler( this.TestLayersButton_Click );
			// 
			// TestMarkersButton
			// 
			this.TestMarkersButton.Location                =  new System.Drawing.Point( 3, 32 );
			this.TestMarkersButton.Name                    =  "TestMarkersButton";
			this.TestMarkersButton.Size                    =  new System.Drawing.Size( 90, 23 );
			this.TestMarkersButton.TabIndex                =  6;
			this.TestMarkersButton.Text                    =  "Test Markers";
			this.TestMarkersButton.UseVisualStyleBackColor =  true;
			this.TestMarkersButton.Click                   += new System.EventHandler( this.TestMarkersButton_Click );
			// 
			// TestImageButton
			// 
			this.TestImageButton.Location                =  new System.Drawing.Point( 3, 3 );
			this.TestImageButton.Name                    =  "TestImageButton";
			this.TestImageButton.Size                    =  new System.Drawing.Size( 90, 23 );
			this.TestImageButton.TabIndex                =  2;
			this.TestImageButton.Text                    =  "Test Image";
			this.TestImageButton.UseVisualStyleBackColor =  true;
			this.TestImageButton.Click                   += new System.EventHandler( this.TestImageButton_Click );
			// 
			// DrawableCtl
			// 
			this.DrawableCtl.BackColor       = System.Drawing.SystemColors.Control;
			this.DrawableCtl.BackgroundColor = System.Drawing.SystemColors.Control;
			this.DrawableCtl.Dock            = System.Windows.Forms.DockStyle.Fill;
			this.DrawableCtl.Location        = new System.Drawing.Point( 0, 0 );
			this.DrawableCtl.Name            = "DrawableCtl";
			this.DrawableCtl.Size            = new System.Drawing.Size( 294, 298 );
			this.DrawableCtl.TabIndex        = 0;
			// 
			// MainAppPanelCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.MainSplitter );
			this.Name = "MainAppPanelCtl";
			this.Size = new System.Drawing.Size( 400, 300 );
			this.MainSplitter.Panel1.ResumeLayout( false );
			this.MainSplitter.Panel2.ResumeLayout( false );
			((System.ComponentModel.ISupportInitialize) (this.MainSplitter)).EndInit();
			this.MainSplitter.ResumeLayout( false );
			this.ResumeLayout( false );
		}

		private Fracter2.View.DrawableCtl DrawableCtl;

		#endregion

		private System.Windows.Forms.SplitContainer MainSplitter;
		private System.Windows.Forms.Button TestImageButton;
		private System.Windows.Forms.Button TestLayersButton;
		private System.Windows.Forms.Button TestMarkersButton;
		private System.Windows.Forms.Button ColorPickerButton;
		private System.Windows.Forms.ColorDialog ColorPicker;
	}
}
