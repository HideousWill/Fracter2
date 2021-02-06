using System.ComponentModel;

namespace Fracter2.View
{
	partial class AppRunner
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}

			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.ApplicationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VeroniMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.oldCountryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RootSplitter = new System.Windows.Forms.SplitContainer();
			this.ConsoleTextBox = new System.Windows.Forms.TextBox();
			this.MenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).BeginInit();
			this.RootSplitter.Panel2.SuspendLayout();
			this.RootSplitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplicationMenuItem});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(584, 24);
			this.MenuStrip.TabIndex = 0;
			this.MenuStrip.Text = "menuStrip1";
			this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
			// 
			// ApplicationMenuItem
			// 
			this.ApplicationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VeroniMenuItem,
            this.oldCountryToolStripMenuItem});
			this.ApplicationMenuItem.Name = "ApplicationMenuItem";
			this.ApplicationMenuItem.Size = new System.Drawing.Size(80, 20);
			this.ApplicationMenuItem.Text = "Application";
			// 
			// VeroniMenuItem
			// 
			this.VeroniMenuItem.Name = "VeroniMenuItem";
			this.VeroniMenuItem.Size = new System.Drawing.Size(180, 22);
			this.VeroniMenuItem.Text = "Veroni";
			this.VeroniMenuItem.Click += new System.EventHandler(this.VeroniMenuItem_Click);
			// 
			// oldCountryToolStripMenuItem
			// 
			this.oldCountryToolStripMenuItem.Name = "oldCountryToolStripMenuItem";
			this.oldCountryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.oldCountryToolStripMenuItem.Text = "Old Country";
			this.oldCountryToolStripMenuItem.Click += new System.EventHandler(this.OldCountryMenuItem_Click);
			// 
			// RootSplitter
			// 
			this.RootSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RootSplitter.Location = new System.Drawing.Point(0, 24);
			this.RootSplitter.Name = "RootSplitter";
			this.RootSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// RootSplitter.Panel2
			// 
			this.RootSplitter.Panel2.Controls.Add(this.ConsoleTextBox);
			this.RootSplitter.Size = new System.Drawing.Size(584, 387);
			this.RootSplitter.SplitterDistance = 276;
			this.RootSplitter.TabIndex = 1;
			this.RootSplitter.TabStop = false;
			// 
			// ConsoleTextBox
			// 
			this.ConsoleTextBox.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ConsoleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConsoleTextBox.Location = new System.Drawing.Point(0, 0);
			this.ConsoleTextBox.Multiline = true;
			this.ConsoleTextBox.Name = "ConsoleTextBox";
			this.ConsoleTextBox.ReadOnly = true;
			this.ConsoleTextBox.Size = new System.Drawing.Size(584, 107);
			this.ConsoleTextBox.TabIndex = 0;
			this.ConsoleTextBox.TabStop = false;
			// 
			// ApplicationHost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 411);
			this.Controls.Add(this.RootSplitter);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "AppRunner";
			this.Text = "ApplicationHost";
			this.Load += new System.EventHandler(this.ApplicationHost_Load);
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.RootSplitter.Panel2.ResumeLayout(false);
			this.RootSplitter.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RootSplitter)).EndInit();
			this.RootSplitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ApplicationMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VeroniMenuItem;
		private System.Windows.Forms.ToolStripMenuItem oldCountryToolStripMenuItem;
		private System.Windows.Forms.SplitContainer RootSplitter;
		private System.Windows.Forms.TextBox ConsoleTextBox;
	}
}