﻿namespace Fracter2.View
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.MainAppPanel       = new Fracter2.View.MainAppPanelCtl();
			this.ConsoleTextBox     = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize) (this.MainSplitContainer)).BeginInit();
			this.MainSplitContainer.Panel1.SuspendLayout();
			this.MainSplitContainer.Panel2.SuspendLayout();
			this.MainSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainSplitContainer
			// 
			this.MainSplitContainer.Anchor      = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.MainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainSplitContainer.Location    = new System.Drawing.Point( 0, 0 );
			this.MainSplitContainer.Name        = "MainSplitContainer";
			this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// MainSplitContainer.Panel1
			// 
			this.MainSplitContainer.Panel1.Controls.Add( this.MainAppPanel );
			// 
			// MainSplitContainer.Panel2
			// 
			this.MainSplitContainer.Panel2.Controls.Add( this.ConsoleTextBox );
			this.MainSplitContainer.Size             = new System.Drawing.Size( 546, 537 );
			this.MainSplitContainer.SplitterDistance = 392;
			this.MainSplitContainer.TabIndex         = 0;
			// 
			// MainAppPanel
			// 
			this.MainAppPanel.Anchor   = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.MainAppPanel.Location = new System.Drawing.Point( -1, -1 );
			this.MainAppPanel.Name     = "MainAppPanel";
			this.MainAppPanel.Size     = new System.Drawing.Size( 542, 388 );
			this.MainAppPanel.TabIndex = 0;
			// 
			// ConsoleTextBox
			// 
			this.ConsoleTextBox.BackColor  = System.Drawing.SystemColors.ControlDark;
			this.ConsoleTextBox.Dock       = System.Windows.Forms.DockStyle.Fill;
			this.ConsoleTextBox.Location   = new System.Drawing.Point( 0, 0 );
			this.ConsoleTextBox.Multiline  = true;
			this.ConsoleTextBox.Name       = "ConsoleTextBox";
			this.ConsoleTextBox.ReadOnly   = true;
			this.ConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ConsoleTextBox.Size       = new System.Drawing.Size( 544, 139 );
			this.ConsoleTextBox.TabIndex   = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize          = new System.Drawing.Size( 546, 537 );
			this.Controls.Add( this.MainSplitContainer );
			this.Name =  "MainForm";
			this.Text =  "Fracter 2";
			this.Load += new System.EventHandler( this.MainForm_Load );
			this.MainSplitContainer.Panel1.ResumeLayout( false );
			this.MainSplitContainer.Panel2.ResumeLayout( false );
			this.MainSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.MainSplitContainer)).EndInit();
			this.MainSplitContainer.ResumeLayout( false );
			this.ResumeLayout( false );
		}

		private System.Windows.Forms.TextBox ConsoleTextBox;

		#endregion

		private System.Windows.Forms.SplitContainer MainSplitContainer;
		private MainAppPanelCtl                     MainAppPanel;
	}
}

