namespace Fracter2.View
{
	partial class VeroniAppCtl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeroniAppCtl));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.AddLayerDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.PointEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RootSplitter = new System.Windows.Forms.SplitContainer();
			this.LayerLegend = new Fracter2.View.LayerLegendCtl();
			this.DrawableSurface = new Fracter2.View.DrawableCtl();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).BeginInit();
			this.RootSplitter.Panel1.SuspendLayout();
			this.RootSplitter.Panel2.SuspendLayout();
			this.RootSplitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLayerDropDownButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(478, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// AddLayerDropDownButton
			// 
			this.AddLayerDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.AddLayerDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointEditorToolStripMenuItem});
			this.AddLayerDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("AddLayerDropDownButton.Image")));
			this.AddLayerDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddLayerDropDownButton.Name = "AddLayerDropDownButton";
			this.AddLayerDropDownButton.Size = new System.Drawing.Size(29, 22);
			this.AddLayerDropDownButton.Text = "Add Layer";
			// 
			// PointEditorToolStripMenuItem
			// 
			this.PointEditorToolStripMenuItem.Name = "PointEditorToolStripMenuItem";
			this.PointEditorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.PointEditorToolStripMenuItem.Text = "Point Editor";
			this.PointEditorToolStripMenuItem.Click += new System.EventHandler(this.PointEditorToolStripMenuItem_Click);
			// 
			// RootSplitter
			// 
			this.RootSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RootSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootSplitter.Location = new System.Drawing.Point(0, 25);
			this.RootSplitter.Name = "RootSplitter";
			// 
			// RootSplitter.Panel1
			// 
			this.RootSplitter.Panel1.AutoScroll = true;
			this.RootSplitter.Panel1.AutoScrollMinSize = new System.Drawing.Size(100, 100);
			this.RootSplitter.Panel1.Controls.Add(this.LayerLegend);
			// 
			// RootSplitter.Panel2
			// 
			this.RootSplitter.Panel2.AutoScroll = true;
			this.RootSplitter.Panel2.AutoScrollMinSize = new System.Drawing.Size(150, 150);
			this.RootSplitter.Panel2.Controls.Add(this.DrawableSurface);
			this.RootSplitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.RootSplitter.Size = new System.Drawing.Size(478, 317);
			this.RootSplitter.SplitterDistance = 159;
			this.RootSplitter.TabIndex = 1;
			// 
			// LayerLegend
			// 
			this.LayerLegend.AutoScroll = true;
			this.LayerLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LayerLegend.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LayerLegend.Location = new System.Drawing.Point(0, 0);
			this.LayerLegend.Name = "LayerLegend";
			this.LayerLegend.Size = new System.Drawing.Size(157, 315);
			this.LayerLegend.TabIndex = 0;
			// 
			// DrawableSurface
			// 
			this.DrawableSurface.BackColor = System.Drawing.SystemColors.Control;
			this.DrawableSurface.BackgroundColor = System.Drawing.SystemColors.Control;
			this.DrawableSurface.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DrawableSurface.Location = new System.Drawing.Point(3, 3);
			this.DrawableSurface.Name = "DrawableSurface";
			this.DrawableSurface.Size = new System.Drawing.Size(307, 309);
			this.DrawableSurface.TabIndex = 0;
			// 
			// VeroniAppCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.RootSplitter);
			this.Controls.Add(this.toolStrip1);
			this.Name = "VeroniAppCtl";
			this.Size = new System.Drawing.Size(478, 342);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.RootSplitter.Panel1.ResumeLayout(false);
			this.RootSplitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).EndInit();
			this.RootSplitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.SplitContainer RootSplitter;
		private DrawableCtl DrawableSurface;
		private LayerLegendCtl LayerLegend;
		private System.Windows.Forms.ToolStripDropDownButton AddLayerDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem PointEditorToolStripMenuItem;
	}
}
