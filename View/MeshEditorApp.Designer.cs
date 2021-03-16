namespace Fracter2.View
{
	partial class MeshEditorApp
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
				OnDispose();
			}
			base.Dispose(disposing);
		}

		partial void OnDispose();

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RootSplitter = new System.Windows.Forms.SplitContainer();
			this.ControlPanel = new Fracter2.View.MeshEditorControlPanel();
			this.DrawingSurface = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).BeginInit();
			this.RootSplitter.Panel1.SuspendLayout();
			this.RootSplitter.Panel2.SuspendLayout();
			this.RootSplitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootSplitter
			// 
			this.RootSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RootSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootSplitter.Location = new System.Drawing.Point(0, 0);
			this.RootSplitter.Name = "RootSplitter";
			// 
			// RootSplitter.Panel1
			// 
			this.RootSplitter.Panel1.Controls.Add(this.ControlPanel);
			// 
			// RootSplitter.Panel2
			// 
			this.RootSplitter.Panel2.AutoScroll = true;
			this.RootSplitter.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.RootSplitter.Panel2.Controls.Add(this.DrawingSurface);
			this.RootSplitter.Size = new System.Drawing.Size(485, 296);
			this.RootSplitter.SplitterDistance = 161;
			this.RootSplitter.TabIndex = 0;
			// 
			// ControlPanel
			// 
			this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ControlPanel.Location = new System.Drawing.Point(0, 0);
			this.ControlPanel.Name = "ControlPanel";
			this.ControlPanel.Size = new System.Drawing.Size(159, 294);
			this.ControlPanel.TabIndex = 0;
			// 
			// DrawingSurface
			// 
			this.DrawingSurface.AutoScroll = true;
			this.DrawingSurface.AutoScrollMinSize = new System.Drawing.Size(256, 256);
			this.DrawingSurface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.DrawingSurface.Location = new System.Drawing.Point(3, 3);
			this.DrawingSurface.MinimumSize = new System.Drawing.Size(256, 256);
			this.DrawingSurface.Name = "DrawingSurface";
			this.DrawingSurface.Size = new System.Drawing.Size(312, 288);
			this.DrawingSurface.TabIndex = 0;
			// 
			// MeshEditorApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RootSplitter);
			this.Name = "MeshEditorApp";
			this.Size = new System.Drawing.Size(485, 296);
			this.Load += new System.EventHandler(this.MeshEditorApp_Load);
			this.RootSplitter.Panel1.ResumeLayout(false);
			this.RootSplitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).EndInit();
			this.RootSplitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer RootSplitter;
		private MeshEditorControlPanel ControlPanel;
		private System.Windows.Forms.Panel DrawingSurface;
	}
}
