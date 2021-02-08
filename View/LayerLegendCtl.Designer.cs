namespace Fracter2.View
{
	partial class LayerLegendCtl
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
			this.label1 = new System.Windows.Forms.Label();
			this.ButtonHolder = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Layers";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonHolder
			// 
			this.ButtonHolder.AutoScroll = true;
			this.ButtonHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonHolder.Location = new System.Drawing.Point(0, 15);
			this.ButtonHolder.Name = "ButtonHolder";
			this.ButtonHolder.Size = new System.Drawing.Size(150, 135);
			this.ButtonHolder.TabIndex = 1;
			// 
			// LayerButtonContainerCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.ButtonHolder);
			this.Controls.Add(this.label1);
			this.Name = "LayerLegendCtl";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel ButtonHolder;
	}
}
